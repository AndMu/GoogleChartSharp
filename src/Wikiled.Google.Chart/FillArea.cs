namespace Wikiled.Google.Chart
{
    /// <summary>
    /// Fill the area between / under lines
    /// </summary>
    public class FillArea
    {
        private readonly FillAreaType type;
        /// <summary>
        /// an RRGGBB format hexadecimal number
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// the index of the line at which the fill starts. This is determined by the order in which data sets are added. The first data set specified has an index of zero (0), the second 1, and so on.
        /// </summary>
        public int StartLineIndex { get; set; }
        /// <summary>
        /// the index of the line at which the fill ends. This is determined by the order in which data sets are added. The first data set specified has an index of zero (0), the second 1, and so on.
        /// </summary>
        public int EndLineIndex { get; set; }

        /// <summary>
        /// Create a fill area between lines for use on a line chart.
        /// </summary>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        /// <param name="startLineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        /// <param name="endLineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        public FillArea(string color, int startLineIndex, int endLineIndex)
        {
            type = FillAreaType.MultiLine;
            Color = color;
            StartLineIndex = startLineIndex;
            EndLineIndex = endLineIndex;
        }

        /// <summary>
        /// Fill all the area under a line
        /// </summary>
        /// <param name="color">an RRGGBB format hexadecimal number</param>
        /// <param name="lineIndex">line indexes are determined by the order in which datasets are added. The first set is index 0, then index 1 etc</param>
        public FillArea(string color, int lineIndex)
        {
            type = FillAreaType.SingleLine;
            Color = color;
            StartLineIndex = lineIndex;
        }

        internal string GetUrlString()
        {
            string s = string.Empty;

            if (type == FillAreaType.MultiLine)
            {
                s += "b" + ",";
                s += Color + ",";
                s += StartLineIndex.ToString() + ",";
                s += EndLineIndex.ToString() + ",";
                s += "0"; // ignored
            }
            else if (type == FillAreaType.SingleLine)
            {
                s += "B" + ",";
                s += Color + ",";
                s += StartLineIndex.ToString() + ",";
                s += "0" + ","; // ignored
                s += "0"; // ignored
            }

            return s;
        }
    }
}
