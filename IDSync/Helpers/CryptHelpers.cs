using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace IDSync.Helpers
{
    public static partial class CryptHelpers
    {
        public static int keySize = 256;
        public static int derivationIterations = 1000;
        public static int blockSize = 256;
        public static CipherMode mode = CipherMode.CBC;
        public static PaddingMode padding = PaddingMode.PKCS7;

        public static int KeySize
        {
            get
            {
                return keySize;
            }
            set
            {
                keySize = value;
            }
        }
        public static int DerivationIterations
        {
            get
            {
                return derivationIterations;
            }
            set
            {
                derivationIterations = value;
            }
        }
        public static int BlockSize
        {
            get
            {
                return blockSize;
            }
            set
            {
                blockSize = value;
            }
        }
        public static CipherMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                mode = value;
            }
        }
        public static PaddingMode Padding
        {
            get
            {
                return padding;
            }
            set
            {
                padding = value;
            }
        }
        public static string Encrypt(string plainText, string passPharase)
        {
            byte[] saltStringBytes = GenerateBitsOfRandomEntropy(32);
            byte[] ivStringBytes = GenerateBitsOfRandomEntropy(32);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPharase, saltStringBytes, derivationIterations))
            {
                byte[] keyBytes = password.GetBytes(keySize / 8);
                using (RijndaelManaged sKey = new RijndaelManaged())
                {
                    sKey.BlockSize = blockSize;
                    sKey.Mode = mode;
                    sKey.Padding = padding;
                    using (var encryptor = sKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (MemoryStream memoystream = new MemoryStream())
                        {
                            using (CryptoStream cryptostream = new CryptoStream(memoystream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptostream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptostream.FlushFinalBlock();

                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoystream.ToArray()).ToArray();
                                memoystream.Close();
                                cryptostream.Close();
                                return Convert.ToBase64String(cipherTextBytes);

                            }
                        }
                    }

                }
            }

        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var salStringBytes = cipherTextBytesWithSaltAndIv.Take(KeySize / 8).ToArray();
            var ivStringButes = cipherTextBytesWithSaltAndIv.Skip(KeySize / 8).Take(KeySize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((KeySize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((KeySize / 8) * 2)).ToArray();

            using (Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, salStringBytes, derivationIterations))
            {
                var keyBytes = password.GetBytes(keySize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = blockSize;
                    symmetricKey.Mode = mode;
                    symmetricKey.Padding = padding;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringButes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                byte[] plaintextBytes = new byte[cipherTextBytes.Length];
                                var decryptByteCount = cryptoStream.Read(plaintextBytes, 0, plaintextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plaintextBytes, 0, decryptByteCount);
                            }
                        }
                    }
                }
            } 
        }

        private static byte[] GenerateBitsOfRandomEntropy(int bits)
        {
            byte[] randomBytes = new byte[bits];
            using (RNGCryptoServiceProvider rgnCSP = new RNGCryptoServiceProvider())
            {
                rgnCSP.GetBytes(randomBytes);
            }

            return randomBytes;
        }

        
        public static SecureString EncPassword(string PlainPassword)
        {
            SecureString Password = new SecureString();
            foreach (char x in PlainPassword)
            {
                Password.AppendChar(x);
            }
            return Password;
        } 
    }
}