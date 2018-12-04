using System;

namespace Wikiled.Google.Chart.Helpers
{
    public class DayOfWeekSampling : ISampling
    {
        public string GetName(DateTime date)
        {
            return date.DayOfWeek.ToString();
        }

        public TimeSpan GetStep()
        {
            return TimeSpan.FromDays(1);
        }
    }
}
