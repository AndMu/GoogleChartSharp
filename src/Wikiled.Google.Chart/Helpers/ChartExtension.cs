using System;
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
    }
}
