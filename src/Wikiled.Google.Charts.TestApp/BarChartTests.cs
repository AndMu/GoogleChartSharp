using System.Collections.Generic;
using Wikiled.Google.Chart;
using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Charts.TestApp
{
    public class BarChartTests
    {
        public static string HorizontalStackedTest()
        {
            int[] data1 = { 10, 5, 20, 15 };
            int[] data2 = { 10, 10, 10, 10 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(data1);
            dataset.Add(data2);

            BarChart barChart = new BarChart(150, 150, BarChartOrientation.Horizontal, BarChartStyle.Stacked);
            barChart.SetTitle("Horizontal Stacked");
            barChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            barChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            barChart.SetData(dataset);

            barChart.SetDatasetColors(new[] { Colors.GetColor("FF0000"), Colors.GetColor("00AA00") });

            return barChart.GetUrl();
        }

        public static string VerticalStackedTest()
        {
            int[] data1 = { 10, 5, 20, 15 };
            int[] data2 = { 10, 10, 10, 10 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(data1);
            dataset.Add(data2);

            BarChart barChart = new BarChart(150, 150, BarChartOrientation.Vertical, BarChartStyle.Stacked);
            barChart.SetTitle("Vertical Stacked");
            barChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            barChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            barChart.SetData(dataset);

            barChart.SetDatasetColors(new[] { Colors.GetColor("FF0000"), Colors.GetColor("00AA00") });

            return barChart.GetUrl();
        }

        public static string HorizontalGroupedTest()
        {
            int[] data1 = { 10, 5, 20 };
            int[] data2 = { 5, 10, 20 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(data1);
            dataset.Add(data2);

            BarChart barChart = new BarChart(150, 150, BarChartOrientation.Horizontal, BarChartStyle.Grouped);
            barChart.SetTitle("Horizontal Grouped");
            barChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            barChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            barChart.SetData(dataset);

            barChart.SetDatasetColors(new[] { Colors.GetColor("FF0000"), Colors.GetColor("00AA00") });
            barChart.SetBarWidth(10);

            return barChart.GetUrl();
        }

        public static string VerticalGroupedTest()
        {
            int[] data1 = { 10, 5, 20 };
            int[] data2 = { 30, 35, 15 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(data1);
            dataset.Add(data2);

            BarChart barChart = new BarChart(300, 150, BarChartOrientation.Vertical, BarChartStyle.Grouped);
            barChart.SetTitle("Vertical Grouped");
            barChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            barChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            barChart.SetData(dataset);

            barChart.SetDatasetColors(new[] { Colors.GetColor("FF0000"), Colors.GetColor("00AA00") });

            return barChart.GetUrl();
        }

        public static string ZeroLineTest()
        {
            int[] data1 = { 10, 5, 20 };
            int[] data2 = { 30, 35, 20 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(data1);
            dataset.Add(data2);

            BarChart barChart = new BarChart(300, 150, BarChartOrientation.Vertical, BarChartStyle.Grouped);
            barChart.SetTitle("Zero Line");
            barChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            barChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            barChart.SetZeroLine(0.25);
            barChart.SetData(dataset);

            barChart.SetDatasetColors(new[] { Colors.GetColor("FF0000"), Colors.GetColor("00AA00") });

            return barChart.GetUrl();
        }
    }
}
