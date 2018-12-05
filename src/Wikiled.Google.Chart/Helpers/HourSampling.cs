using System;

namespace Wikiled.Google.Chart.Helpers
{
    public class HourSampling : ISampling
    {
        public string GetName(DateTime date)
        {
            return date.Hour.ToString();
        }

        public TimeSpan GetStep()
        {
            return TimeSpan.FromHours(1);
        }
    }
}