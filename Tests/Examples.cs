using Wikiled.Google.Chart;

namespace Wikiled.Google.Charts.TestApp
{
    class Examples
    {
        public static string SuperSimple()
        {
            int[] data = new[] { 0, 10, 20, 30, 40 };
            LineChart chart = new LineChart(150, 150);
            chart.SetData(data);
            return chart.GetUrl();
        }

        public static string SimpleAxis()
        {
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);

            int[] line1 = new[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.AddAxis(bottomAxis);
            lineChart.SetData(line1);
            return lineChart.GetUrl();
        }

        public static string AxisLabels()
        {
            ChartAxis leftAxis = new ChartAxis(ChartAxisType.Left, new[] { "one", "two", "three" });
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
            bottomAxis.AddLabel(new ChartAxisLabel("a", 0));
            bottomAxis.AddLabel(new ChartAxisLabel("b", 10));
            bottomAxis.AddLabel(new ChartAxisLabel("c", 50));
            bottomAxis.AddLabel(new ChartAxisLabel("d", 100));

            int[] line1 = new[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.AddAxis(leftAxis);
            lineChart.AddAxis(bottomAxis);
            lineChart.SetData(line1);
            return lineChart.GetUrl();
        }

        public static string AxisRange()
        {
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
            bottomAxis.SetRange(0, 50);

            int[] line1 = new[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.AddAxis(bottomAxis);
            lineChart.SetData(line1);
            return lineChart.GetUrl();
        }

        public static string StackingAxes()
        {
            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
            ChartAxis bottomAxis2 = new ChartAxis(ChartAxisType.Bottom);
            bottomAxis2.SetRange(0, 50);

            int[] line1 = new[] { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(150, 150);

            lineChart.AddAxis(bottomAxis);
            lineChart.AddAxis(bottomAxis2);

            lineChart.SetData(line1);
            return lineChart.GetUrl();
        }

        public static string Xkcd()
        {
            float[] data = new float[] {35, 30, 26, 22, 17,  5, 96,  5,  4,  3,  2,  2,  1,  1};

            string[] axisLabels = new[] {".00", ".02", ".04", ".06", ".08", ".10",
                                                ".12", ".14", ".16", ".18", ".20", ".22",
                                                ".24", ".26"};

            ChartAxis bottomAxis = new ChartAxis(ChartAxisType.Bottom);
            bottomAxis.SetRange(0, 30);

            for (int i = 0; i < axisLabels.Length; i++)
            {
                bottomAxis.AddLabel(new ChartAxisLabel(axisLabels[i], i*2));
            }

            ChartAxis bottomAxis2 = new ChartAxis(ChartAxisType.Bottom);
            bottomAxis2.AddLabel(new ChartAxisLabel("Blood Alcohol Concentration (%)", 50));

            LineChart lineChart = new LineChart(400, 200);
            lineChart.SetTitle("Programming Skill", "000000", 14);
            lineChart.SetData(data);
            lineChart.AddAxis(bottomAxis);
            lineChart.AddAxis(bottomAxis2);
            return lineChart.GetUrl();
        }
    }
}
