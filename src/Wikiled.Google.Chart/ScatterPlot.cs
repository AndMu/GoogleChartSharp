namespace Wikiled.Google.Chart
{
    public class ScatterPlot : Chart
    {
        /// <summary>
        ///     Create a scatter plot
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public ScatterPlot(int width, int height)
            : base(width, height)
        {
        }

        protected override string UrlChartType()
        {
            return "s";
        }

        protected override ChartType GetChartType()
        {
            return ChartType.ScatterPlot;
        }
    }
}