using System.Diagnostics;
using System.IO;

namespace Wikiled.Google.Charts.TestApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter tw = new StreamWriter(("test.html")))
            {
                tw.WriteLine("<h3>Axes</h3>");
                tw.WriteLine(GetImageTag(AxesTests.AllBasicAxesTest()));
                tw.WriteLine(GetImageTag(AxesTests.AxesLabelsTest()));
                tw.WriteLine(GetImageTag(AxesTests.AxesRangeTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(AxesTests.AxesStyleTest()));
                tw.WriteLine(GetImageTag(AxesTests.StackedAxesTest()));

                tw.WriteLine("<h3>Line Charts</h3>");
                tw.WriteLine(GetImageTag(LineChartTests.SingleDatasetPerLine()));
                tw.WriteLine(GetImageTag(LineChartTests.MultiDatasetPerLine()));
                tw.WriteLine(GetImageTag(LineChartTests.LineColorAndLegendTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(LineChartTests.LineStyleTest()));
                tw.WriteLine(GetImageTag(LineChartTests.Sparklines()));

                tw.WriteLine("<h3>Fills</h3>");
                tw.WriteLine(GetImageTag(FillsTests.MultiLineAreaFillsTest()));
                tw.WriteLine(GetImageTag(FillsTests.SingleLineAreaFillTest()));
                tw.WriteLine(GetImageTag(FillsTests.LinearGradientFillTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(FillsTests.LinearStripesTest()));
                tw.WriteLine(GetImageTag(FillsTests.SolidFillTest()));

                tw.WriteLine("<h3>Markers</h3>");
                tw.WriteLine(GetImageTag(MarkersTests.RangeMarkersTest()));
                tw.WriteLine(GetImageTag(MarkersTests.ShapeMarkersTest()));

                tw.WriteLine("<h3>Grids</h3>");
                tw.WriteLine(GetImageTag(GridTests.StepSizeTest()));
                tw.WriteLine(GetImageTag(GridTests.AllParamsTest()));
                tw.WriteLine(GetImageTag(GridTests.SolidGridTest()));

                tw.WriteLine("<h3>Bar Charts</h3>");
                tw.WriteLine(GetImageTag(BarChartTests.HorizontalStackedTest()));
                tw.WriteLine(GetImageTag(BarChartTests.VerticalStackedTest()));
                tw.WriteLine(GetImageTag(BarChartTests.HorizontalGroupedTest()));
                tw.WriteLine(GetImageTag(BarChartTests.VerticalGroupedTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(BarChartTests.ZeroLineTest()));

                tw.WriteLine("<h3>Pie Charts</h3>");
                tw.WriteLine(GetImageTag(PieChartTests.TwoDTest()));
                tw.WriteLine(GetImageTag(PieChartTests.ThreeDTest()));

                tw.WriteLine("<h3>Venn Diagrams</h3>");
                tw.WriteLine(GetImageTag(VennDiagramTests.VennDiagramTest()));

                tw.WriteLine("<h3>Scatter Plots</h3>");
                tw.WriteLine(GetImageTag(ScatterPlotTests.ScatterPlotTest()));

                tw.WriteLine("<h3>Examples</h3>");
                tw.WriteLine(GetImageTag(Examples.SimpleAxis()));
                tw.WriteLine(GetImageTag(Examples.AxisLabels()));
                tw.WriteLine(GetImageTag(Examples.AxisRange()));
                tw.WriteLine(GetImageTag(Examples.StackingAxes()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(Examples.Xkcd()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(Examples.SuperSimple()));
            }

            Process.Start(new FileInfo("test.html").FullName);
        }

        static string GetImageTag(string url)
        {
            return "<img src=\"" + url + "\" />";
        }
    }
}
