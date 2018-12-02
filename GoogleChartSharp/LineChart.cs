using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    /// <summary>
    /// Specifies how the line chart handles datasets
    /// </summary>
    public enum LineChartType
    {
        /// <summary>
        /// One line per dataset, points are evenly spaced along the x-axis
        /// </summary>
        SingleDataSet,

        /// <summary>
        /// Two datasets per line. The first dataset is the x coordinates 
        /// of the line. The second dataset is the Y coordinates of the line.
        /// </summary>
        MultiDataSet,

        /// <summary>
        /// A sparkline chart has exactly the same parameters as a line chart. 
        /// The only difference is that the axes lines are not drawn for sparklines 
        /// by default. You can add axes labels if you wish.
        /// </summary>
        Sparklines
    }

    public class LineChart : Chart
    {
        private LineChartType lineChartType = LineChartType.SingleDataSet;
        private List<LineStyle> lineStyles = new List<LineStyle>();

        /// <summary>
        /// Create a line chart with one line per dataset. Points are evenly spaced along the x-axis.
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public LineChart(int width, int height) 
            : base(width, height)
        {
            this.lineChartType = LineChartType.SingleDataSet;
        }

        /// <summary>
        /// Create a line chart with the specified type.
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
            if (this.lineChartType == LineChartType.MultiDataSet)
            {
                return "lxy";
            }
            if (this.lineChartType == LineChartType.Sparklines)
            {
                return "ls";
            }
            return "lc";
        }

        /// <summary>
        /// Apply a style to a line. Line styles are applied to lines in order, the 
        /// first line will use the first line style.
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
                string s = "chls=";
                foreach (LineStyle lineStyle in lineStyles)
                {
                    s += lineStyle.LineThickness.ToString() + ",";
                    s += lineStyle.LengthOfSegment.ToString() + ",";
                    s += lineStyle.LengthOfBlankSegment.ToString() + "|";
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
