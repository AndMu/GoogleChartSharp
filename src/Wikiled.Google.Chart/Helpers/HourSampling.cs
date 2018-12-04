using System;

namespace Wikiled.Google.Chart.Helpers
{
    public class HourSampling : ISampling
    {
        public DateTime GetNext(DateTime dateTime)
        {
            return dateTime.AddHours(1);
        }

        public string GetName(DateTime date)
        {
            return date.Hour.ToString();
        }
    }
}