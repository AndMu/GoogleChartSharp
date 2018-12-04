using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart
{
    public class RangeMarker
    {
        /// <summary>
        ///     Create a range marker for line charts and scatter plots
        /// </summary>
        /// <param name="rangeMarkerType"></param>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        /// <param name="startPoint">Must be between 0.0 and 1.0. 0.0 is axis start, 1.0 is axis end.</param>
        /// <param name="endPoint">Must be between 0.0 and 1.0. 0.0 is axis start, 1.0 is axis end.</param>
        public RangeMarker(RangeMarkerType rangeMarkerType, Color color, double startPoint, double endPoint)
        {
            Type = rangeMarkerType;
            Color = color;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }

        public RangeMarkerType Type { get; set; }

        /// <summary>
        ///     an RRGGBB format hexadecimal number.
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        ///     for horizontal range markers is the position on the y-axis at which the range starts where 0.00 is the bottom and
        ///     1.00 is the top.
        ///     for vertical range markers is the position on the x-axis at which the range starts where 0.00 is the left and 1.00
        ///     is the right.
        /// </summary>
        public double StartPoint { get; set; }

        /// <summary>
        ///     for horizontal range markers is the position on the y-axis at which the range ends where 0.00 is the bottom and
        ///     1.00 is the top.
        ///     for vertical range markers is the position on the x-axis at which the range ends where 0.00 is the left and 1.00 is
        ///     the right.
        /// </summary>
        public double EndPoint { get; set; }

        public string GetTypeUrlChar()
        {
            switch (Type)
            {
                case RangeMarkerType.Horizontal:
                    return "r";
                case RangeMarkerType.Vertical:
                    return "R";
            }

            return null;
        }

        public string GetUrlString()
        {
            var s = string.Empty;
            s += GetTypeUrlChar() + ",";
            s += Color.Code + ",";
            // this value is ignored - but has to be a number
            s += "0" + ",";
            s += StartPoint + ",";
            s += EndPoint.ToString();
            return s;
        }
    }
}