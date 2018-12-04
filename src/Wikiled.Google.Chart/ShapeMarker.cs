using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart
{
    public class ShapeMarker
    {
        /// <summary>
        ///     Create a shape marker for points on line charts and scatter plots
        /// </summary>
        /// <param name="markerType"></param>
        /// <param name="hexColor">RRGGBB format hexadecimal number</param>
        /// <param name="datasetIndex">
        ///     the index of the line on which to draw the marker. This is 0 for the first data set, 1 for
        ///     the second and so on
        /// </param>
        /// <param name="dataPoint">
        ///     a floating point value that specifies on which data point the marker will be drawn. This is 1
        ///     for the first data set, 2 for the second and so on. Specify a fraction to interpolate a marker between two points.
        /// </param>
        /// <param name="size">the size of the marker in pixels</param>
        public ShapeMarker(ShapeMarkerType markerType, Color color, int datasetIndex, float dataPoint, int size)
        {
            Type = markerType;
            HexColor = color;
            DatasetIndex = datasetIndex;
            DataPoint = dataPoint;
            Size = size;
        }

        public ShapeMarkerType Type { get; set; }

        /// <summary>
        ///     an RRGGBB format hexadecimal number.
        /// </summary>
        public Color HexColor { get; set; }

        /// <summary>
        ///     the index of the line on which to draw the marker. This is 0 for the first data set, 1 for the second and so on
        /// </summary>
        public int DatasetIndex { get; set; }

        /// <summary>
        ///     a floating point value that specifies on which data point the marker will be drawn. This is 1 for the first data
        ///     set, 2 for the second and so on. Specify a fraction to interpolate a marker between two points
        /// </summary>
        public float DataPoint { get; set; }

        /// <summary>
        ///     the size of the marker in pixels
        /// </summary>
        public int Size { get; set; }

        internal string GetTypeUrlChar()
        {
            switch (Type)
            {
                case ShapeMarkerType.Arrow:
                    return "a";
                case ShapeMarkerType.Cross:
                    return "c";
                case ShapeMarkerType.Diamond:
                    return "d";
                case ShapeMarkerType.Circle:
                    return "o";
                case ShapeMarkerType.Square:
                    return "s";
                case ShapeMarkerType.VerticalLineToDataPoint:
                    return "v";
                case ShapeMarkerType.VerticalLine:
                    return "V";
                case ShapeMarkerType.HorizontalLine:
                    return "h";
                case ShapeMarkerType.XShape:
                    return "x";
            }

            return null;
        }

        internal string GetUrlString()
        {
            var s = string.Empty;
            s += GetTypeUrlChar() + ",";
            s += HexColor.Code + ",";
            s += DatasetIndex + ",";
            s += DataPoint + ",";
            s += Size.ToString();
            return s;
        }
    }
}