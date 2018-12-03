using System.Collections.Generic;
using Wikiled.Google.Chart;

namespace Wikiled.Google.Charts.TestApp
{
    class LineChartTests
    {
        public static string SingleDatasetPerLine()
        {
            int[] line1 = { 5, 10, 50, 34, 10, 25 };
            int[] line2 = { 15, 20, 60, 44, 20, 35 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(line1);
            dataset.Add(line2);

            LineChart lineChart = new LineChart(250, 150);
            lineChart.SetTitle("Single Dataset Per Line", Colors.GetColor("0000FF"), 14);
            lineChart.SetData(dataset);
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));

            return lineChart.GetUrl();
        }

        public static string Sparklines()
        {
            float[] line1 = { 27, 25, 25, 25, 25, 27, 100, 31, 25, 36, 25, 25, 39, 25, 31, 25, 25, 25, 26, 26, 25, 25, 28, 25, 25, 100, 28, 27, 31, 25, 27, 27, 29, 25, 27, 26, 26, 25, 26, 26, 35, 33, 34, 25, 26, 25, 36, 25, 26, 37, 33, 33, 37, 37, 39, 25, 25, 25, 25 };

            List<float[]> dataset = new List<float[]>();
            dataset.Add(line1);

            LineChart lineChart = new LineChart(250, 150, LineChartType.Sparklines);
            lineChart.SetData(dataset);
            lineChart.SetTitle("Sparklines test");

            return lineChart.GetUrl();
        }

        public static string MultiDatasetPerLine()
        {
            int[] line1X = { 0, 15, 30, 45, 60 };
            int[] line1Y = { 10, 50, 15, 60, 12};
            int[] line2X = { 0, 15, 30, 45, 60 };
            int[] line2Y = { 45, 12, 60, 34, 60 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(line1X);
            dataset.Add(line1Y);
            dataset.Add(line2X);
            dataset.Add(line2Y);

            LineChart lineChart = new LineChart(250, 150, LineChartType.MultiDataSet);
            lineChart.SetTitle("Multi Dataset Per Line", Colors.GetColor("0000FF"), 14);
            lineChart.SetData(dataset);
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));

            return lineChart.GetUrl();
        }

        public static string LineColorAndLegendTest()
        {
            int[] line1 = { 5, 10, 50, 34, 10, 25 };
            int[] line2 = { 15, 20, 60, 44, 20, 35 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(line1);
            dataset.Add(line2);

            LineChart lineChart = new LineChart(250, 150);
            lineChart.SetTitle("Line Color And Legend Test", Colors.GetColor("0000FF"), 14);
            lineChart.SetData(dataset);
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));

            lineChart.SetDatasetColors(new[] { Colors.GetColor("FF0000"), Colors.GetColor("00FF00") });
            lineChart.SetLegend(new[] { "line1", "line2" });

            return lineChart.GetUrl();
        }

        public static string LineStyleTest()
        {
            int[] line1 = { 5, 10, 50, 34, 10, 25 };
            int[] line2 = { 15, 20, 60, 44, 20, 35 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(line1);
            dataset.Add(line2);

            LineChart lineChart = new LineChart(250, 150);
            lineChart.SetTitle("Line Style Test", Colors.GetColor("0000FF"), 14);
            lineChart.SetData(dataset);
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));

            lineChart.AddLineStyle(new LineStyle(2, 5, 1));
            lineChart.AddLineStyle(new LineStyle(1, 1, 5));

            return lineChart.GetUrl();
        }
    }
}
