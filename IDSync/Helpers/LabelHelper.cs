using System; 

namespace IDSync.Helpers
{
    public class LabelHelper
    { 

        public static string LabelTracking(DateTime start, DateTime end)
        {
            var timeTrack = end.Subtract(start).TotalMinutes;
            string label = "";
            if (timeTrack > 30)
            {
                label = "danger";
            }
            else if (timeTrack >= 15 && timeTrack <= 30)
            {
                label = "warning";
            }
            else
            {
                label = "completed";
            }
            return label;
        }
    }
}