using System.Collections.Generic;
using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart
{
    public interface IChart
    {
        int Height { get; set; }

        int Width { get; set; }

        int TotalPoints { get; }

        int TotalSeries { get; }

        IChart AddAxis(ChartAxis axis);

        IChart AddFillArea(FillArea fillArea);

        IChart AddLinearGradientFill(LinearGradientFill linearGradientFill);

        IChart AddLinearStripesFill(LinearStripesFill linearStripesFill);

        IChart AddRangeMarker(RangeMarker rangeMarker);

        IChart AddShapeMarker(ShapeMarker shapeMarker);

        IChart AddSolidFill(SolidFill solidFill);

        string GetUrl();

        IChart SetData(float[] data);

        IChart SetData(ICollection<float[]> data);

        IChart SetData(ICollection<int[]> data);

        IChart SetData(ICollection<long[]> data);

        IChart SetData(int[] data);

        IChart SetData(long[] data);

        IChart SetDatasetColors(Color[] datasetColors);

        IChart SetGrid(float xAxisStepSize, float yAxisStepSize);

        IChart SetGrid(float xAxisStepSize, float yAxisStepSize, float lengthLineSegment, float lengthBlankSegment);

        IChart SetLegend(string[] labels);

        IChart SetTitle(string title);

        IChart SetTitle(string title, Color color);

        IChart SetTitle(string title, Color color, int fontSize);
    }
}