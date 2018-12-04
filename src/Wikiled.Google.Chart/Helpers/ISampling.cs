using System;

namespace Wikiled.Google.Chart.Helpers
{
    public interface ISampling
    {
        string GetName(DateTime date);
        DateTime GetNext(DateTime dateTime);
    }
}