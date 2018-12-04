using System;

namespace Wikiled.Google.Chart.Helpers
{
    public class DayOfWeekSampling : ISampling
    {
        public DateTime GetNext(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }

        public string GetName(DateTime date)
        {
            return date.DayOfWeek.ToString();
        }
    }
}
