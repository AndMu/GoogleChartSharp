using System;
using System.Collections.Generic;
using System.Linq;
using Deedle;

namespace Wikiled.Google.Chart.Helpers
{
    public class DatasetHelper
    {
        private readonly FrameBuilder.Columns<DateTime, string> frameBuilder = new FrameBuilder.Columns<DateTime, string>();

        private readonly ISampling sampling;

        public DatasetHelper(ISampling sampling)
        {
            this.sampling = sampling ?? throw new ArgumentNullException(nameof(sampling));
        }

        public void AddSeries(string name, DataPoint[] points)
        {
            var newColumn = GetSeries(points);
            frameBuilder.Add(name, newColumn);
        }

        public void Populate(IChart chart)
        {
            var frame = frameBuilder.Frame.FillMissing(0f);
            List<float[]> values = new List<float[]>();
            foreach (var columns in frame.GetAllColumns<float>())
            {
                values.Add(columns.Value.Values.ToArray());
            }

            List<string> days = new List<string>();
            for (int i = 0; i < frame.RowIndex.Keys.Count; i++)
            {
                days.Add(sampling.GetName(frame.RowIndex.Keys[i]));
            }

            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom, days.ToArray()));
            chart.SetData(values);
        }

        private Series<DateTime, float> GetSeries(DataPoint[] points)
        {
            SeriesBuilder<DateTime, float> seriesBuilder = new SeriesBuilder<DateTime, float>();
            foreach (var point in points.GroupBy(item => item.Date))
            {
                seriesBuilder.Add(point.Key, point.Average(item => item.Value));
            }

            return seriesBuilder.Series.ResampleUniform(item => item.Date, item => sampling.GetNext(item.Date), Lookup.Exact).SortByKey();
        }
    }
}
