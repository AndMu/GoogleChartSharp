using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    public interface IChart
    {
        int Height { get; set; }
        int Width { get; set; }

        void AddAxis(ChartAxis axis);
        void AddFillArea(FillArea fillArea);
        void AddLinearGradientFill(LinearGradientFill linearGradientFill);
        void AddLinearStripesFill(LinearStripesFill linearStripesFill);
        void AddRangeMarker(RangeMarker rangeMarker);
        void AddShapeMarker(ShapeMarker shapeMarker);
        void AddSolidFill(SolidFill solidFill);
        string GetUrl();
        void SetData(float[] data);
        void SetData(ICollection<float[]> data);
        void SetData(ICollection<int[]> data);
        void SetData(ICollection<long[]> data);
        void SetData(int[] data);
        void SetData(long[] data);
        void SetDatasetColors(string[] datasetColors);
        void SetGrid(float xAxisStepSize, float yAxisStepSize);
        void SetGrid(float xAxisStepSize, float yAxisStepSize, float lengthLineSegment, float lengthBlankSegment);
        void SetLegend(string[] strs);
        void SetTitle(string title);
        void SetTitle(string title, string color);
        void SetTitle(string title, string color, int fontSize);
    }
}