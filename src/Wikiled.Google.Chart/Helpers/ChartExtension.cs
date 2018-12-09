using System;
using System.Collections.Generic;
using System.Linq;

namespace Wikiled.Google.Chart.Helpers
{
    public static class ChartExtension
    {
        private static readonly Color[] defaultColor =
        {
            Colors.Red,
            Colors.Green,
            Colors.Navy,
            Colors.Olive,
            Colors.Purple,
            Colors.Navy,
            Colors.Aqua,
            Colors.Teal,
            Colors.LightBlue,
            Colors.Maroon,
            Colors.Silver
        };

        public static IChart SetAutoColors(this IChart chart)
        {
            if (chart == null)
            {
                throw new ArgumentNullException(nameof(chart));
            }

            if (chart.TotalSeries == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(chart), "Series not setup");
            }

            if (chart.TotalSeries > defaultColor.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(chart), "Too many data series");
            }

            return chart.SetDatasetColors(defaultColor.Take(chart.TotalSeries).ToArray());
        }

        public static LineChart AddLineStyleAll(this LineChart chart, LineStyle style)
        {
            if (chart == null)
            {
                throw new ArgumentNullException(nameof(chart));
            }

            if (style == null)
            {
                throw new ArgumentNullException(nameof(style));
            }

            for (int i = 0; i < chart.TotalSeries; i++)
            {
                chart.AddLineStyle(style);
            }

            return chart;
        }

        public static IChart AdjustYScaleZero(this IChart chart, float max = 1, float step = 0.1f)
        {
            chart.AddRangeMarker(new RangeMarker(RangeMarkerType.Horizontal, Colors.Black, 0.499, 0.501));
            List<string> labels = new List<string>();
            for (var i = -max; i < max; i += step)
            {
                labels.Add(Math.Round(i, 2).ToString());
            }

            chart.AddAxis(new ChartAxis(ChartAxisType.Left, labels.ToArray()));
            return chart;
        }

        public static IChart Populate(this IChart chart, ITimeSeries series, Func<DateTime, int, bool> labelSampling = null)
        {
            List<string> days = new List<string>();
            for (int i = 0; i < series.XAxis.Length; i++)
            {
                var current = series.XAxis[i];
                if (labelSampling == null ||
                    labelSampling(current, i))
                {
                    days.Add(series.Sampling.GetName(current));
                }
            }

            chart.SetLegend(series.SeriesNames);
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom, days.ToArray()));
            chart.SetData(series.Points);
            chart.SetAutoColors();
            return chart;
        }
    }
}
