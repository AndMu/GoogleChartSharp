using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    public class LinearGradientFill
    {
        private readonly List<ColorOffsetPair> colorOffsetPairs = new List<ColorOffsetPair>();

        /// <summary>
        ///     Create a linear gradient
        /// </summary>
        /// <param name="fillTarget">area to be filled</param>
        /// <param name="angle">specifies the angle of the gradient between 0 (horizontal) and 90 (vertical)</param>
        public LinearGradientFill(ChartFillTarget fillTarget, int angle)
        {
            FillTarget = fillTarget;
            Angle = angle;
        }

        /// <summary>
        ///     The area that will be filled.
        /// </summary>
        public ChartFillTarget FillTarget { get; set; }

        /// <summary>
        ///     specifies the angle of the gradient between 0 (horizontal) and 90 (vertical)
        /// </summary>
        public int Angle { get; set; }

        /// <summary>
        ///     Add a color/offset pair to the linear gradient
        /// </summary>
        /// <param name="color">RRGGBB format hexadecimal number</param>
        /// <param name="offset">
        ///     specify at what point the color is pure where: 0 specifies the right-most chart position and 1 the
        ///     left-most
        /// </param>
        public void AddColorOffsetPair(string color, double offset)
        {
            colorOffsetPairs.Add(new ColorOffsetPair(color, offset));
        }

        internal string GetTypeUrlChar()
        {
            switch (FillTarget)
            {
                case ChartFillTarget.ChartArea:
                    return "c";
                case ChartFillTarget.Background:
                    return "bg";
            }

            return null;
        }

        internal string GetUrlString()
        {
            var s = string.Empty;
            s += GetTypeUrlChar() + ",";
            s += "lg,";
            s += Angle + ",";

            foreach (var colorOffsetPair in colorOffsetPairs)
            {
                s += colorOffsetPair.Color + ",";
                s += colorOffsetPair.Offset + ",";
            }

            return s.TrimEnd(",".ToCharArray());
        }
    }
}