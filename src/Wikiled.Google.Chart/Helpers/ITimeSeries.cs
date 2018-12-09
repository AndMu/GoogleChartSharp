using System;
using System.Collections.Generic;

namespace Wikiled.Google.Chart.Helpers
{
    public interface ITimeSeries
    {
        bool IsGenerated { get; }

        ISampling Sampling { get; }

        IList<float[]> Points { get; }

        string[] SeriesNames { get; }

        DateTime[] XAxis { get; }

        void Rescale(Func<float, float> scale);

        void AddSeries(string name, DataPoint[] points);

        void Generate();
    }
}