using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart
{
    internal class ColorOffsetPair
    {
        /// <summary>
        ///     RRGGBB format hexadecimal number
        /// </summary>
        public readonly Color Color;

        /// <summary>
        ///     specify at what point the color is pure where: 0 specifies the right-most
        ///     chart position and 1 the left-most.
        /// </summary>
        public readonly double Offset;

        /// <summary>
        /// </summary>
        /// <param name="color">RRGGBB format hexadecimal number</param>
        /// <param name="offset">
        ///     specify at what point the color is pure where: 0 specifies the right-most chart position and 1 the
        ///     left-most
        /// </param>
        public ColorOffsetPair(Color color, double offset)
        {
            Color = color;
            Offset = offset;
        }
    }
}