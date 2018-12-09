using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Deedle;

namespace Wikiled.Google.Chart.Helpers
{
    public class TimeSeries : ITimeSeries
    {
        private readonly FrameBuilder.Columns<DateTime, string> frameBuilder = new FrameBuilder.Columns<DateTime, string>();

        public TimeSeries(ISampling sampling)
        {
            Sampling = sampling ?? throw new ArgumentNullException(nameof(sampling));
        }
        public ISampling Sampling { get; }

        public bool IsGenerated { get; private set; }

        public DateTime[] XAxis { get; private set; }

        public string[] SeriesNames { get; private set; }

        public IList<float[]> Points { get; private set; }

        public void AddSeries(string name, DataPoint[] points)
        {
            Series<DateTime, float> newColumn = GetSeries(points);
            frameBuilder.Add(name, newColumn);
        }

        public void Rescale(Func<float, float> scale)
        {
            Points = new ReadOnlyCollection<float[]>(Points.Select(item => item.Select(scale).ToArray()).ToList());
        }

        public void Generate()
        {
            if (IsGenerated)
            {
                return;
            }

            IsGenerated = true;
            Frame<DateTime, string> frame = frameBuilder.Frame.FillMissing(0f);
            Series<DateTime, float> emptySeries = frame.GetColumnAt<float>(0).Observations.Select(item => new KeyValuePair<DateTime, float>(item.Key, 0)).ToSeries();

            emptySeries = emptySeries.Sample(Sampling.GetStep());
            emptySeries = emptySeries.EndAt(frame.RowIndex.KeyAt(frame.RowIndex.KeyCount - 1));
            frameBuilder.Add("NULL", emptySeries);
            frame = frameBuilder.Frame.FillMissing(0f);
            frame.DropColumn("NULL");

            List<float[]> values = new List<float[]>();
            List<string> labels = new List<string>();
            foreach (KeyValuePair<string, Series<DateTime, float>> columns in frame.GetAllColumns<float>())
            {
                values.Add(columns.Value.Values.ToArray());
                labels.Add(columns.Key);
            }

            Points = values.AsReadOnly();
            SeriesNames = labels.ToArray();
            XAxis = frame.RowIndex.Keys.ToArray();
        }

        private Series<DateTime, float> GetSeries(DataPoint[] points)
        {
            SeriesBuilder<DateTime, float> seriesBuilder = new SeriesBuilder<DateTime, float>();
            foreach (IGrouping<DateTime, DataPoint> point in points.GroupBy(item => Sampling.GroupByDate(item.Date)))
            {
                seriesBuilder.Add(point.Key, point.Average(item => item.Value));
            }

            return seriesBuilder.Series.SortByKey();
        }
    }
}
