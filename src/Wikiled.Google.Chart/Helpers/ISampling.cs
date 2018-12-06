using System;

namespace Wikiled.Google.Chart.Helpers
{
    public interface ISampling
    {
        string GetName(DateTime date);

        TimeSpan GetStep();

        DateTime GroupByDate(DateTime date);
    }
}