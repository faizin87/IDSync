using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDSync.Helpers
{
    public class StringHelpers
    {
        public static string UppercaseWords(string value)
        {
            char[] array = value.ToLower().ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array).Replace("Dpn", "DPN").Replace("DPK", "DPK").Replace("Asn", "ASN").Replace("Bkn","BKN").Replace("Iii", "III").Replace("Ii", "II").Replace("Iv", "IV").Replace("Ix", "IX").Replace("Viii", "VIII").Replace("Vii", "VII").Replace("Vi", "VI").Replace("Xiii", "XIII").Replace("Xii", "XII").Replace("Xi", "XI");
        }
        public static string LimitCharacters(string text, int length)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            // If text in shorter or equal to length, just return it
            if (text.Length <= length)
            {
                return text;
            }

            // Text is longer, so try to find out where to cut
            char[] delimiters = new char[] { ' ', '.', ',', ':', ';' };
            int index = text.LastIndexOfAny(delimiters, length - 3);

            if (index > (length / 2))
            {
                return text.Substring(0, index) + "...";
            }
            else
            {
                return text.Substring(0, length - 3) + "...";
            }
        }
    }
}