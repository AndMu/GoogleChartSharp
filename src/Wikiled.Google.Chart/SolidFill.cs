namespace Wikiled.Google.Chart
{
    public class SolidFill
    {
        /// <summary>
        ///     Create a solid fill
        /// </summary>
        /// <param name="fillTarget">The area that will be filled.</param>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        public SolidFill(ChartFillTarget fillTarget, Color color)
        {
            FillTarget = fillTarget;
            Color = color;
        }

        /// <summary>
        ///     The area that will be filled.
        /// </summary>
        public ChartFillTarget FillTarget { get; set; }

        /// <summary>
        ///     an RRGGBB format hexadecimal number
        /// </summary>
        public Color Color { get; set; }

        private string GetTypeUrlChar()
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

        public string GetUrlString()
        {
            var s = string.Empty;
            s += GetTypeUrlChar() + ",";
            s += "s,";
            s += Color.Code;
            return s;
        }
    }
}