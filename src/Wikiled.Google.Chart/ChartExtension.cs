using System;
using System.Collections.Generic;
using System.Linq;

namespace Wikiled.Google.Chart
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
            if (chart.DataSize > defaultColor.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(chart), "Too many data series");
            }

            return chart.SetDatasetColors(defaultColor.Take(chart.DataSize).ToArray());
        }

        public static LineChart AddLineStyleAll(this LineChart chart, LineStyle style)
        {
            for (int i = 0; i < chart.DataSize; i++)
            {
                chart.AddLineStyle(style);
            }

            return chart;
        }
    }
}
