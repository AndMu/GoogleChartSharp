using System.Collections.Generic;
using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart
{
    public class LinearStripesFill
    {
        private readonly List<ColorWidthPair> colorWidthPairs = new List<ColorWidthPair>();

        /// <summary>
        ///     Create a linear stripes fill.
        /// </summary>
        /// <param name="fillTarget">The area that will be filled.</param>
        /// <param name="angle">specifies the angle of the gradient between 0 (vertical) and 90 (horizontal)</param>
        public LinearStripesFill(ChartFillTarget fillTarget, int angle)
        {
            FillTarget = fillTarget;
            Angle = angle;
        }

        /// <summary>
        ///     The area that will be filled.
        /// </summary>
        public ChartFillTarget FillTarget { get; set; }

        /// <summary>
        ///     specifies the angle of the gradient between 0 (vertical) and 90 (horizontal)
        /// </summary>
        public int Angle { get; set; }

        /// <summary>
        ///     A color/width pair describes a linear stripe.
        /// </summary>
        /// <param name="color">RRGGBB format hexadecimal number</param>
        /// <param name="width">must be between 0 and 1 where 1 is the full width of the chart</param>
        public void AddColorWidthPair(Color color, double width)
        {
            colorWidthPairs.Add(new ColorWidthPair(color, width));
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
            s += "ls,";
            s += Angle + ",";

            foreach (var colorWidthPair in colorWidthPairs)
            {
                s += colorWidthPair.Color.Code + ",";
                s += colorWidthPair.Width + ",";
            }

            return s.TrimEnd(",".ToCharArray());
        }
    }
}