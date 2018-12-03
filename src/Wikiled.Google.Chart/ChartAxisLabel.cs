namespace Wikiled.Google.Chart
{
    /// <summary>
    ///     Describes an axis label
    /// </summary>
    public class ChartAxisLabel
    {
        /// <summary>
        ///     A value within the axis range
        /// </summary>
        public float Position;

        /// <summary>
        ///     This text will be displayed on the axis
        /// </summary>
        public string Text;

        /// <summary>
        ///     Create an axis label without position information, labels will be evenly spaced on the axis
        /// </summary>
        /// <param name="text">The label text</param>
        public ChartAxisLabel(string text)
            : this(text, -1)
        {
        }

        /// <summary>
        ///     Create an axis label without label text. The axis label will be evenly spaced on the axis and the text will
        ///     be it's numeric position within the axis range.
        /// </summary>
        /// <param name="position"></param>
        public ChartAxisLabel(float position)
            : this(null, position)
        {
        }

        /// <summary>
        ///     Create an axis label with label text and position.
        /// </summary>
        /// <param name="text">The label text</param>
        /// <param name="position">The label position within the axis range</param>
        public ChartAxisLabel(string text, float position)
        {
            Text = text;
            Position = position;
        }
    }
}