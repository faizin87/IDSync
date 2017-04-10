namespace IDSync.Helpers
{
    public class SQLHelpers
    { 
        public static string replaceLimit(string inp)
        {
            string input = inp.ToLower();
            int ORC = input.IndexOf("where rownum");
            int ORCL = input.IndexOf("rownum");
            int SQL = input.IndexOf("limit");
            if (ORC > 0)
            {
                input = input.Substring(0, ORC);
            }
            else
            {
                if (ORCL > 0)
                {
                    input = input.Substring(0, ORCL);
                }
                else
                {
                    if (SQL > 0)
                    {
                        input = input.Substring(0, SQL);
                    }
                }
            }
            return input;
        }

    }
}