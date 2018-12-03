namespace Wikiled.Google.Chart
{
    internal class ColorWidthPair
    {
        /// <summary>
        ///     RRGGBB format hexadecimal number
        /// </summary>
        public readonly string Color;

        /// <summary>
        ///     must be between 0 and 1 where 1 is the full width of the chart
        /// </summary>
        public readonly double Width;

        /// <summary>
        ///     Describes a linear stripe. Stripes are repeated until the chart is filled.
        /// </summary>
        /// <param name="color">RGGBB format hexadecimal number</param>
        /// <param name="width">must be between 0 and 1 where 1 is the full width of the chart</param>
        public ColorWidthPair(string color, double width)
        {
            Color = color;
            Width = width;
        }
    }
}