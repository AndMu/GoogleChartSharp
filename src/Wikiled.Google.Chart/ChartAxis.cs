using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    /// <summary>
    ///     Chart Axis
    /// </summary>
    public class ChartAxis
    {
        private readonly List<ChartAxisLabel> axisLabels = new List<ChartAxisLabel>();
        private readonly ChartAxisType axisType;
        private int lowerBound;
        private bool rangeSet;
        private int upperBound;

        /// <summary>
        ///     Create an axis, default is range 0 - 100 evenly spaced. You can create multiple axes of the same ChartAxisType.
        /// </summary>
        /// <param name="axisType">Axis position</param>
        public ChartAxis(ChartAxisType axisType)
            : this(axisType, null)
        {
        }

        /// <summary>
        ///     Create an axis, default is range 0 - 100 evenly spaced. You can create multiple axes of the same ChartAxisType.
        /// </summary>
        /// <param name="axisType">Axis position</param>
        /// <param name="labels">These labels will be added to the axis without position information</param>
        public ChartAxis(ChartAxisType axisType, string[] labels)
        {
            this.axisType = axisType;

            if (labels != null)
            {
                foreach (var label in labels)
                {
                    axisLabels.Add(new ChartAxisLabel(label, -1));
                }
            }
        }

        /// <summary>
        ///     an RRGGBB format hexadecimal number
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        ///     optional if used this specifies the size in pixels
        /// </summary>
        public int FontSize { get; set; } = -1;

        /// <summary>
        ///     By default: x-axis labels are centered, left y-axis labels are right aligned, right y-axis labels are left aligned
        /// </summary>
        public AxisAlignmentType Alignment { get; set; } = AxisAlignmentType.Unset;

        /// <summary>
        ///     Specify the axis range
        /// </summary>
        /// <param name="lowerBound">the lowest value on the axis</param>
        /// <param name="upperBound">the highest value on the axis</param>
        public ChartAxis SetRange(int lowerBound, int upperBound)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
            rangeSet = true;
            return this;
        }

        /// <summary>
        ///     Add a label to the axis
        /// </summary>
        /// <param name="axisLabel"></param>
        public ChartAxis AddLabel(ChartAxisLabel axisLabel)
        {
            axisLabels.Add(axisLabel);
            return this;
        }

        internal string UrlAxisStyle()
        {
            if (Color == null)
            {
                return null;
            }

            var result = Color.Code + ",";
            if (FontSize != -1)
            {
                result += FontSize + ",";
            }

            if (Alignment != AxisAlignmentType.Unset)
            {
                switch (Alignment)
                {
                    case AxisAlignmentType.Left:
                        result += "-1,";
                        break;
                    case AxisAlignmentType.Centered:
                        result += "0,";
                        break;
                    case AxisAlignmentType.Right:
                        result += "1,";
                        break;
                }
            }

            return result.TrimEnd(",".ToCharArray());
        }

        internal string UrlAxisType()
        {
            switch (axisType)
            {
                case ChartAxisType.Bottom:
                    return "x";

                case ChartAxisType.Top:
                    return "t";

                case ChartAxisType.Left:
                    return "y";

                case ChartAxisType.Right:
                    return "r";
            }

            return null;
        }

        internal string UrlLabels()
        {
            var result = "|";
            foreach (var label in axisLabels)
            {
                result += label.Text + "|";
            }

            return result;
        }

        internal string UrlLabelPositions()
        {
            var result = string.Empty;
            foreach (var axisLabel in axisLabels)
            {
                if (axisLabel.Position == -1)
                {
                    return null;
                }

                result += axisLabel.Position + ",";
            }

            return result.TrimEnd(",".ToCharArray());
        }

        internal string UrlRange()
        {
            if (rangeSet)
            {
                return lowerBound + "," + upperBound;
            }

            return null;
        }
    }
}