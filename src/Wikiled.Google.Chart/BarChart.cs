namespace Wikiled.Google.Chart
{
    /// <summary>
    ///     Bar Chart
    /// </summary>
    public class BarChart : Chart
    {
        private readonly BarChartOrientation orientation;
        private readonly BarChartStyle style;
        private int barWidth;
        private double zeroLine;

        /// <summary>
        ///     Create a bar chart
        /// </summary>
        /// <param name="width">Width in pixels</param>
        /// <param name="height">Height in pixels</param>
        /// <param name="orientation">The orientation of the bars.</param>
        /// <param name="style">Bar chart style when using multiple data sets</param>
        public BarChart(int width, int height, BarChartOrientation orientation, BarChartStyle style)
            : base(width, height)
        {
            this.orientation = orientation;
            this.style = style;
        }

        /// <summary>
        ///     Set the width of the individual bars
        /// </summary>
        /// <param name="width">Width in pixels</param>
        public void SetBarWidth(int width)
        {
            barWidth = width;
        }

        /// <summary>
        ///     Specify a zero line
        /// </summary>
        /// <param name="zeroLine"></param>
        public void SetZeroLine(double zeroLine)
        {
            this.zeroLine = zeroLine;
        }

        /// <summary>
        ///     Return the chart identifier used in the chart url.
        /// </summary>
        /// <returns></returns>
        protected override string UrlChartType()
        {
            var orientationChar = orientation == BarChartOrientation.Horizontal ? 'h' : 'v';
            var styleChar = style == BarChartStyle.Stacked ? 's' : 'g';

            return $"b{orientationChar}{styleChar}";
        }

        /// <summary>
        ///     Collect all the elements that will make up the chart url.
        /// </summary>
        protected override void CollectUrlElements()
        {
            base.CollectUrlElements();
            if (barWidth != 0)
            {
                UrlElements.Enqueue($"chbh={barWidth}");
            }

            if (zeroLine != 0)
            {
                UrlElements.Enqueue($"chp={zeroLine}");
            }
        }

        /// <summary>
        ///     Return the chart type for this chart
        /// </summary>
        /// <returns></returns>
        protected override ChartType GetChartType()
        {
            return ChartType.BarChart;
        }
    }
}