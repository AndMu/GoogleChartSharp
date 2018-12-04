using Wikiled.Google.Chart;
using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Charts.TestApp
{
    class MarkersTests
    {
        public static string RangeMarkersTest()
        {
            float[] fdata = { 10, 30, 75, 40, 15 };
            LineChart chart = new LineChart(250, 150);
            chart.SetTitle("Range markers test");
            chart.SetData(fdata);

            chart.AddAxis(new ChartAxis(ChartAxisType.Left));
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

            chart.AddRangeMarker(new RangeMarker(RangeMarkerType.Horizontal, Colors.GetColor("EFEFEF"), 0.2, 0.7));
            chart.AddRangeMarker(new RangeMarker(RangeMarkerType.Vertical, Colors.GetColor("CCCCCC"), 0.4, 0.6));

            return chart.GetUrl();
        }

        public static string ShapeMarkersTest()
        {
            float[] fdata = { 10, 30, 75, 40, 15 };
            LineChart chart = new LineChart(300, 150);
            chart.SetTitle("Shape markers test");
            chart.SetData(fdata);

            chart.AddAxis(new ChartAxis(ChartAxisType.Left));
            chart.AddAxis(new ChartAxis(ChartAxisType.Bottom));

            chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.Arrow, Colors.GetColor("FF0000"), 0, 0, 5));
            chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.Circle, Colors.GetColor("00FF00"), 0, 1, 15));
            chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.Cross, Colors.GetColor("0000FF"), 0, 2, 15));
            chart.AddShapeMarker(new ShapeMarker(ShapeMarkerType.VerticalLine, Colors.GetColor("FF0000"), 0, 3, 2));

            return chart.GetUrl();
        }
    }
}
