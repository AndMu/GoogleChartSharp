using System.Collections.Generic;
using Wikiled.Google.Chart;

namespace Wikiled.Google.Charts.TestApp
{
    class FillsTests
    {
        public static string SolidFillTest()
        {
            int[] line1 = { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(250, 150);
            lineChart.SetTitle("Solid fill test");
            lineChart.SetData(line1);

            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

            SolidFill bgFill = new SolidFill(ChartFillTarget.Background, Colors.GetColor("EFEFEF"));
            SolidFill chartAreaFill = new SolidFill(ChartFillTarget.ChartArea, Colors.GetColor("000000"));

            lineChart.AddSolidFill(bgFill);
            lineChart.AddSolidFill(chartAreaFill);

            return lineChart.GetUrl();
        }

        public static string LinearGradientFillTest()
        {
            int[] line1 = { 5, 10, 50, 34, 10, 25 };
            LineChart lineChart = new LineChart(250, 150);
            lineChart.SetTitle("Linear Gradient fill test");
            lineChart.SetData(line1);

            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

            LinearGradientFill fill = new LinearGradientFill(ChartFillTarget.ChartArea, 45);
            fill.AddColorOffsetPair(Colors.GetColor("FFFFFF"), 0);
            fill.AddColorOffsetPair(Colors.GetColor("76A4FB"), 0.75);

            SolidFill bgFill = new SolidFill(ChartFillTarget.Background, Colors.GetColor("EFEFEF"));

            lineChart.AddLinearGradientFill(fill);
            lineChart.AddSolidFill(bgFill);

            return lineChart.GetUrl();
        }

        public static string LinearStripesTest()
        {
            float[] fdata = { 10, 30, 75, 40, 15 };
            LineChart chart = new LineChart(250, 150);
            chart.SetTitle("Linear Stripes Test");
            chart.SetData(fdata);

            chart.AddAxis(new ChartAxis(ChartAxisType.Left));
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

            LinearStripesFill linearStripesFill = new LinearStripesFill(ChartFillTarget.ChartArea, 0);
            linearStripesFill.AddColorWidthPair(Colors.GetColor("CCCCCC"), 0.2);
            linearStripesFill.AddColorWidthPair(Colors.GetColor("FFFFFF"), 0.2);
            chart.AddLinearStripesFill(linearStripesFill);

            chart.AddSolidFill(new SolidFill(ChartFillTarget.Background, Colors.GetColor("EFEFEF")));
            
            return chart.GetUrl();
        }

        public static string SingleLineAreaFillTest()
        {
            float[] fdata = { 10, 30, 75, 40, 15 };
            LineChart chart = new LineChart(250, 150);
            chart.SetTitle("Area fill test");
            chart.SetData(fdata);

            chart.AddAxis(new ChartAxis(ChartAxisType.Left));
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

            chart.AddFillArea(new FillArea(Colors.GetColor("224499"), 0));
            
            return chart.GetUrl();
        }

        public static string MultiLineAreaFillsTest()
        {
            float[] line1 = { 15, 45, 5, 30, 10 };
            float[] line2 = { 35, 65, 25, 50, 30 };
            float[] line3 = { 55, 85, 45, 70, 50 };

            List<float[]> dataset = new List<float[]>();
            dataset.Add(line1);
            dataset.Add(line2);
            dataset.Add(line3);

            LineChart lineChart = new LineChart(250, 150, LineChartType.SingleDataSet);
            lineChart.SetTitle("Area fills test");
            lineChart.SetData(dataset);

            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

            lineChart.AddFillArea(new FillArea(Colors.GetColor("FF0000"), 0, 1));
            lineChart.AddFillArea(new FillArea(Colors.GetColor("224499"), 1, 2));

            return lineChart.GetUrl();
        }

    }
}
