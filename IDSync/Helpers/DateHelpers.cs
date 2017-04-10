using System; 

namespace IDSync.Helpers
{
    public class DateHelpers
    {
        public static string EofficeTimeSpan(DateTime start, DateTime end)
        { 
            var timeTrack = end.Subtract(start).TotalMinutes;
            double timeShow = 0;
            string stringTimeShow = "";

            if (timeTrack >= 60)
            {
                timeShow = end.Subtract(start).TotalHours;
                if (timeShow >= 24)
                {
                    timeShow = end.Subtract(start).Days;
                    stringTimeShow = timeShow.ToString() + " hari";
                }
                else
                {
                    stringTimeShow = Math.Round(timeShow).ToString() + " jam";
                }
            }
            else
            {
                timeShow = Math.Round(timeTrack, 2);
                stringTimeShow = timeShow.ToString() + " menit";
            }
            return stringTimeShow;
        }
    }
}