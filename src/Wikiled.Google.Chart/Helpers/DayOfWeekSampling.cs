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

        public DateTime GroupByDate(DateTime date)
        {
            return date.Date;
        }
    }
}
