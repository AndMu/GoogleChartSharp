using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    public class LineChart : Chart
    {
        private readonly LineChartType lineChartType;

        private readonly List<LineStyle> lineStyles = new List<LineStyle>();

        /// <summary>
        ///     Create a line chart with one line per dataset. Points are evenly spaced along the x-axis.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public LineChart(int width, int height)
            : base(width, height)
        {
            lineChartType = LineChartType.SingleDataSet;
        }

        /// <summary>
        ///     Create a line chart with the specified type.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        /// <param name="lineChartType">specifies how the chart handles datasets</param>
        public LineChart(int width, int height, LineChartType lineChartType)
            : base(width, height)
        {
            this.lineChartType = lineChartType;
        }

        protected override string UrlChartType()
        {
            if (lineChartType == LineChartType.MultiDataSet)
            {
                return "lxy";
            }

            if (lineChartType == LineChartType.Sparklines)
            {
                return "ls";
            }

            return "lc";
        }

        /// <summary>
        ///     Apply a style to a line. Line styles are applied to lines in order, the
        ///     first line will use the first line style.
        /// </summary>
        /// <param name="lineStyle"></param>
        public void AddLineStyle(LineStyle lineStyle)
        {
            lineStyles.Add(lineStyle);
        }

        protected override void CollectUrlElements()
        {
            base.CollectUrlElements();
            if (lineStyles.Count > 0)
            {
                var s = "chls=";
                foreach (var lineStyle in lineStyles)
                {
                    s += lineStyle.LineThickness + ",";
                    s += lineStyle.LengthOfSegment + ",";
                    s += lineStyle.LengthOfBlankSegment + "|";
                }

                UrlElements.Enqueue(s.TrimEnd("|".ToCharArray()));
            }
        }

        protected override ChartType GetChartType()
        {
            return ChartType.LineChart;
        }
    }
}