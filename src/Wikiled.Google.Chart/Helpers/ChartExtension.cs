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
            if (chart.TotalRows > defaultColor.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(chart), "Too many data series");
            }

            return chart.SetDatasetColors(defaultColor.Take(chart.TotalRows).ToArray());
        }

        public static LineChart AddLineStyleAll(this LineChart chart, LineStyle style)
        {
            for (int i = 0; i < chart.TotalRows; i++)
            {
                chart.AddLineStyle(style);
            }

            return chart;
        }
    }
}
