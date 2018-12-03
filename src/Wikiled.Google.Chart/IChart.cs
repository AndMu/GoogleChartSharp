using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    public interface IChart
    {
        int Height { get; set; }

        int Width { get; set; }

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

        IChart SetDatasetColors(string[] datasetColors);

        IChart SetGrid(float xAxisStepSize, float yAxisStepSize);

        IChart SetGrid(float xAxisStepSize, float yAxisStepSize, float lengthLineSegment, float lengthBlankSegment);

        IChart SetLegend(string[] strs);

        IChart SetTitle(string title);

        IChart SetTitle(string title, string color);

        IChart SetTitle(string title, string color, int fontSize);
    }
}