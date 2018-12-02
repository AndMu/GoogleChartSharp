using System.Diagnostics;
using System.IO;

namespace Wikiled.Google.Charts.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TextWriter tw = new StreamWriter(("test.html")))
            {

                #region Axes
                tw.WriteLine("<h3>Axes</h3>");
                tw.WriteLine(GetImageTag(AxesTests.AllBasicAxesTest()));
                tw.WriteLine(GetImageTag(AxesTests.AxesLabelsTest()));
                tw.WriteLine(GetImageTag(AxesTests.AxesRangeTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(AxesTests.AxesStyleTest()));
                tw.WriteLine(GetImageTag(AxesTests.StackedAxesTest()));
                #endregion

                # region Line Charts
                tw.WriteLine("<h3>Line Charts</h3>");
                tw.WriteLine(GetImageTag(LineChartTests.SingleDatasetPerLine()));
                tw.WriteLine(GetImageTag(LineChartTests.MultiDatasetPerLine()));
                tw.WriteLine(GetImageTag(LineChartTests.LineColorAndLegendTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(LineChartTests.LineStyleTest()));
                tw.WriteLine(GetImageTag(LineChartTests.Sparklines()));
                #endregion

                #region Fills
                tw.WriteLine("<h3>Fills</h3>");
                tw.WriteLine(GetImageTag(FillsTests.MultiLineAreaFillsTest()));
                tw.WriteLine(GetImageTag(FillsTests.SingleLineAreaFillTest()));
                tw.WriteLine(GetImageTag(FillsTests.LinearGradientFillTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(FillsTests.LinearStripesTest()));
                tw.WriteLine(GetImageTag(FillsTests.SolidFillTest()));
                #endregion

                #region Markers
                tw.WriteLine("<h3>Markers</h3>");
                tw.WriteLine(GetImageTag(MarkersTests.RangeMarkersTest()));
                tw.WriteLine(GetImageTag(MarkersTests.ShapeMarkersTest()));

                #endregion

                #region Grids
                tw.WriteLine("<h3>Grids</h3>");
                tw.WriteLine(GetImageTag(GridTests.StepSizeTest()));
                tw.WriteLine(GetImageTag(GridTests.AllParamsTest()));
                tw.WriteLine(GetImageTag(GridTests.SolidGridTest()));
                #endregion

                #region Bar Charts
                tw.WriteLine("<h3>Bar Charts</h3>");
                tw.WriteLine(GetImageTag(BarChartTests.HorizontalStackedTest()));
                tw.WriteLine(GetImageTag(BarChartTests.VerticalStackedTest()));
                tw.WriteLine(GetImageTag(BarChartTests.HorizontalGroupedTest()));
                tw.WriteLine(GetImageTag(BarChartTests.VerticalGroupedTest()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(BarChartTests.ZeroLineTest()));
                #endregion

                #region Pie Charts
                tw.WriteLine("<h3>Pie Charts</h3>");
                tw.WriteLine(GetImageTag(PieChartTests.TwoDTest()));
                tw.WriteLine(GetImageTag(PieChartTests.ThreeDTest()));
                #endregion

                # region Venn Diagrams
                tw.WriteLine("<h3>Venn Diagrams</h3>");
                tw.WriteLine(GetImageTag(VennDiagramTests.VennDiagramTest()));
                #endregion

                # region Scatter Plots
                tw.WriteLine("<h3>Scatter Plots</h3>");
                tw.WriteLine(GetImageTag(ScatterPlotTests.ScatterPlotTest()));
                #endregion

                #region Examples
                tw.WriteLine("<h3>Examples</h3>");
                tw.WriteLine(GetImageTag(Examples.SimpleAxis()));
                tw.WriteLine(GetImageTag(Examples.AxisLabels()));
                tw.WriteLine(GetImageTag(Examples.AxisRange()));
                tw.WriteLine(GetImageTag(Examples.StackingAxes()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(Examples.Xkcd()));
                tw.WriteLine("<br />");
                tw.WriteLine(GetImageTag(Examples.SuperSimple()));
                #endregion
            }

            Process.Start(new FileInfo("test.html").FullName);
        }

        static string GetImageTag(string url)
        {
            return "<img src=\"" + url + "\" />";
        }
    }
}
