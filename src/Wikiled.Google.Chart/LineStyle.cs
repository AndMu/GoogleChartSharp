namespace Wikiled.Google.Chart
{
    public class LineStyle
    {
        /// <summary>
        /// line thickness in pixels
        /// </summary>
        public float LineThickness { get; set; }

        /// <summary>
        /// length of each solid line segment in pixels
        /// </summary>
        public float LengthOfSegment { get; set; }

        /// <summary>
        /// length of each blank line segment in pixels
        /// </summary>
        public float LengthOfBlankSegment { get; set; }

        /// <summary>
        /// Create a line style
        /// </summary>
        /// <param name="lineThickness">line thickness in pixels</param>
        /// <param name="lengthOfSegment">length of each solid line segment in pixels</param>
        /// <param name="lengthOfBlankSegment">length of each blank line segment in pixels</param>
        public LineStyle(float lineThickness, float lengthOfSegment, float lengthOfBlankSegment)
        {
            LineThickness = lineThickness;
            LengthOfSegment = lengthOfSegment;
            LengthOfBlankSegment = lengthOfBlankSegment;
        }
    }
}
