using System;
using System.Collections.Generic;
using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart
{
    /// <summary>
    ///     Base type for all charts.
    /// </summary>
    public abstract class Chart : IChart
    {
        private string ApiBase = "http://chart.apis.google.com/chart?";

        private readonly List<ChartAxis> axes = new List<ChartAxis>();

        private readonly List<FillArea> fillAreas = new List<FillArea>();

        private readonly List<string> legendStrings = new List<string>();

        private readonly List<LinearGradientFill> linearGradientFills = new List<LinearGradientFill>();

        private readonly List<LinearStripesFill> linearStripesFills = new List<LinearStripesFill>();

        private readonly List<RangeMarker> rangeMarkers = new List<RangeMarker>();

        private readonly List<ShapeMarker> shapeMarkers = new List<ShapeMarker>();

        private readonly List<SolidFill> solidFills = new List<SolidFill>();

        private string data;

        private Color[] datasetColors;
        private float gridLengthBlankSegment = -1;
        private float gridLengthLineSegment = -1;

        private bool gridSet;
        private float gridXAxisStepSize = -1;
        private float gridYAxisStepSize = -1;

        private string title;
        private string titleColor;

        /// <summary>
        ///     Create a chart
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        protected Chart(int width, int height)
        {
            Width = width;
            Height = height;
        }

        internal Queue<string> UrlElements { get; } = new Queue<string>();

        public int TotalRows { get; private set; }

        /// <summary>
        ///     Chart width in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        ///     Chart height in pixels.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        ///     Set chart to use single integer dataset
        /// </summary>
        /// <param name="data"></param>
        public IChart SetData(int[] data)
        {
            this.data = ChartData.Encode(data);
            TotalRows = 1;
            return this;
        }

        /// <summary>
        ///     Set chart to use integer dataset collection
        /// </summary>
        /// <param name="data"></param>
        public IChart SetData(ICollection<int[]> data)
        {
            this.data = ChartData.Encode(data);
            TotalRows = data.Count;
            return this;
        }

        /// <summary>
        ///     Set chart to use single float dataset
        /// </summary>
        /// <param name="data"></param>
        public IChart SetData(float[] data)
        {
            this.data = ChartData.Encode(data);
            TotalRows = 1;
            return this;
        }

        /// <summary>
        ///     Set chart to use float dataset collection
        /// </summary>
        /// <param name="data"></param>
        public IChart SetData(ICollection<float[]> data)
        {
            this.data = ChartData.Encode(data);
            TotalRows = data.Count;
            return this;
        }

        /// <summary>
        ///     Set chart to use single long dataset
        /// </summary>
        /// <param name="data"></param>
        public IChart SetData(long[] data)
        {
            this.data = ChartData.Encode(data);
            TotalRows = 1;
            return this;
        }

        /// <summary>
        ///     Set chart to use long dataset collection
        /// </summary>
        /// <param name="data"></param>
        public IChart SetData(ICollection<long[]> data)
        {
            this.data = ChartData.Encode(data);
            TotalRows = data.Count;
            return this;
        }

        /// <summary>
        ///     Set chart title using default color and font size
        /// </summary>
        /// <param name="title">chart title text</param>
        public IChart SetTitle(string title)
        {
            var urlTitle = title.Replace(" ", "+");
            urlTitle = urlTitle.Replace(Environment.NewLine, "|");
            this.title = urlTitle;
            return this;
        }

        /// <summary>
        ///     Set chart title using default font size
        /// </summary>
        /// <param name="title">chart title text</param>
        /// <param name="color">chart title color an RRGGBB format hexadecimal number</param>
        public IChart SetTitle(string title, Color color)
        {
            SetTitle(title);
            titleColor = color.Code;
            return this;
        }

        /// <summary>
        ///     Set chart title
        /// </summary>
        /// <param name="title">chart title text</param>
        /// <param name="color">chart title color an RRGGBB format hexadecimal number</param>
        /// <param name="fontSize">chart title font size in pixels</param>
        public IChart SetTitle(string title, Color color, int fontSize)
        {
            SetTitle(title);
            titleColor = color.Code + "," + fontSize;
            return this;
        }

        /// <summary>
        ///     Set the color for each dataset, match colors to datasets by
        ///     specifying them in the same order the datasets were added to the
        ///     chart.
        /// </summary>
        /// <param name="datasetColors">an array of RRGGBB format hexadecimal numbers</param>
        public IChart SetDatasetColors(Color[] datasetColors)
        {
            this.datasetColors = datasetColors;
            return this;
        }

        /// <summary>
        ///     Add a solid fill to this chart.
        /// </summary>
        /// <param name="solidFill"></param>
        public IChart AddSolidFill(SolidFill solidFill)
        {
            solidFills.Add(solidFill);
            return this;
        }

        /// <summary>
        ///     Add a linear gradient fill to this chart.
        /// </summary>
        /// <param name="linearGradientFill"></param>
        public IChart AddLinearGradientFill(LinearGradientFill linearGradientFill)
        {
            linearGradientFills.Add(linearGradientFill);
            return this;
        }

        /// <summary>
        ///     Add a linear stripes fill to this chart.
        /// </summary>
        /// <param name="linearStripesFill"></param>
        public IChart AddLinearStripesFill(LinearStripesFill linearStripesFill)
        {
            linearStripesFills.Add(linearStripesFill);
            return this;
        }

        /// <summary>
        ///     Add a grid to the chart using default line segment and blank line segment length.
        /// </summary>
        /// <param name="xAxisStepSize">Space between x-axis grid lines in relation to axis range.</param>
        /// <param name="yAxisStepSize">Space between y-axis grid lines in relation to axis range.</param>
        public IChart SetGrid(float xAxisStepSize, float yAxisStepSize)
        {
            var chartType = GetChartType();
            if (!(chartType == ChartType.LineChart || chartType == ChartType.ScatterPlot))
            {
                throw new InvalidFeatureForChartTypeException();
            }

            gridXAxisStepSize = xAxisStepSize;
            gridYAxisStepSize = yAxisStepSize;
            gridLengthLineSegment = -1;
            gridLengthBlankSegment = -1;
            gridSet = true;
            return this;
        }

        /// <summary>
        ///     Add a grid to the chart.
        /// </summary>
        /// <param name="xAxisStepSize">Space between x-axis grid lines in relation to axis range.</param>
        /// <param name="yAxisStepSize">Space between y-axis grid lines in relation to axis range.</param>
        /// <param name="lengthLineSegment">Length of each line segment in a grid line</param>
        /// <param name="lengthBlankSegment">Length of each blank segment in a grid line</param>
        public IChart SetGrid(float xAxisStepSize, float yAxisStepSize, float lengthLineSegment, float lengthBlankSegment)
        {
            var chartType = GetChartType();
            if (!(chartType == ChartType.LineChart || chartType == ChartType.ScatterPlot))
            {
                throw new InvalidFeatureForChartTypeException();
            }

            gridXAxisStepSize = xAxisStepSize;
            gridYAxisStepSize = yAxisStepSize;
            gridLengthLineSegment = lengthLineSegment;
            gridLengthBlankSegment = lengthBlankSegment;
            gridSet = true;
            return this;
        }

        /// <summary>
        ///     Add a fill area to the chart. Fill areas are fills between / under lines.
        /// </summary>
        /// <param name="fillArea"></param>
        public IChart AddFillArea(FillArea fillArea)
        {
            fillAreas.Add(fillArea);
            return this;
        }

        /// <summary>
        ///     Add a shape marker to the chart. Shape markers are used to call attention to a data point on the chart.
        /// </summary>
        /// <param name="shapeMarker"></param>
        public IChart AddShapeMarker(ShapeMarker shapeMarker)
        {
            shapeMarkers.Add(shapeMarker);
            return this;
        }

        /// <summary>
        ///     Add a range marker to the chart. Range markers are colored bands on the chart.
        /// </summary>
        /// <param name="rangeMarker"></param>
        public IChart AddRangeMarker(RangeMarker rangeMarker)
        {
            rangeMarkers.Add(rangeMarker);
            return this;
        }

        /// <summary>
        ///     Set chart legend
        /// </summary>
        /// <param name="labels">legend labels</param>
        public virtual IChart SetLegend(string[] labels)
        {
            foreach (var label in labels)
            {
                legendStrings.Add(label);
            }

            return this;
        }

        /// <summary>
        ///     Add an axis to the chart
        /// </summary>
        /// <param name="axis"></param>
        public IChart AddAxis(ChartAxis axis)
        {
            axes.Add(axis);
            return this;
        }

        /// <summary>
        ///     Return the chart api url for this chart
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            CollectUrlElements();
            return GenerateUrlString();
        }

        private string GetGridUrlElement()
        {
            if (gridXAxisStepSize != -1 && gridYAxisStepSize != -1)
            {
                var s = $"chg={gridXAxisStepSize.ToString()},{gridYAxisStepSize.ToString()}";
                if (gridLengthLineSegment != -1 && gridLengthBlankSegment != -1)
                {
                    s += "," + gridLengthLineSegment + "," + gridLengthBlankSegment;
                }

                return s;
            }

            return null;
        }

        private string GetFillAreasUrlElement()
        {
            var s = string.Empty;
            foreach (var fillArea in fillAreas)
            {
                s += fillArea.GetUrlString() + "|";
            }

            return s.TrimEnd("|".ToCharArray());
        }

        private string GetShapeMarkersUrlElement()
        {
            var s = string.Empty;
            foreach (var shapeMarker in shapeMarkers)
            {
                s += shapeMarker.GetUrlString() + "|";
            }

            return s.TrimEnd("|".ToCharArray());
        }

        private string GetRangeMarkersUrlElement()
        {
            var s = string.Empty;
            foreach (var rangeMarker in rangeMarkers)
            {
                s += rangeMarker.GetUrlString() + "|";
            }

            return s.TrimEnd("|".ToCharArray());
        }

        /// <summary>
        ///     Returns the api chart identifier for the chart
        /// </summary>
        /// <returns></returns>
        protected abstract string UrlChartType();

        protected abstract ChartType GetChartType();

        /// <summary>
        ///     Collect all the elements that will be used in the chart url
        /// </summary>
        protected virtual void CollectUrlElements()
        {
            UrlElements.Clear();
            UrlElements.Enqueue($"cht={UrlChartType()}");
            UrlElements.Enqueue($"chs={Width}x{Height}");
            UrlElements.Enqueue(data);

            // chart title
            if (title != null)
            {
                UrlElements.Enqueue($"chtt={title}");
            }

            if (titleColor != null)
            {
                UrlElements.Enqueue($"chts={titleColor}");
            }

            // dataset colors
            if (datasetColors != null)
            {
                var s = "chco=";
                foreach (var color in datasetColors)
                {
                    s += color.Code + ",";
                }

                UrlElements.Enqueue(s.TrimEnd(",".ToCharArray()));
            }

            // Fills
            var fillsString = "chf=";
            if (solidFills.Count > 0)
            {
                foreach (var solidFill in solidFills)
                {
                    fillsString += solidFill.GetUrlString() + "|";
                }
            }

            if (linearGradientFills.Count > 0)
            {
                foreach (var linearGradient in linearGradientFills)
                {
                    fillsString += linearGradient.GetUrlString() + "|";
                }
            }

            if (linearStripesFills.Count > 0)
            {
                foreach (var linearStripesFill in linearStripesFills)
                {
                    fillsString += linearStripesFill.GetUrlString() + "|";
                }
            }

            if (solidFills.Count > 0 || linearGradientFills.Count > 0 || linearStripesFills.Count > 0)
            {
                UrlElements.Enqueue(fillsString.TrimEnd("|".ToCharArray()));
            }

            // Legends
            if (legendStrings.Count > 0)
            {
                var s = "chdl=";
                foreach (var str in legendStrings)
                {
                    s += str + "|";
                }

                UrlElements.Enqueue(s.TrimEnd("|".ToCharArray()));
            }

            // Axes
            if (axes.Count > 0)
            {
                var axisTypes = "chxt=";
                var axisLabels = "chxl=";
                var axisLabelPositions = "chxp=";
                var axisRange = "chxr=";
                var axisStyle = "chxs=";

                var axisIndex = 0;
                foreach (var axis in axes)
                {
                    axisTypes += axis.UrlAxisType() + ",";
                    axisLabels += axisIndex + ":" + axis.UrlLabels();
                    var labelPositions = axis.UrlLabelPositions();
                    if (!string.IsNullOrEmpty(labelPositions))
                    {
                        axisLabelPositions += axisIndex + "," + labelPositions + "|";
                    }

                    var axisRangeStr = axis.UrlRange();
                    if (!string.IsNullOrEmpty(axisRangeStr))
                    {
                        axisRange += axisIndex + "," + axisRangeStr + "|";
                    }

                    var axisStyleStr = axis.UrlAxisStyle();
                    if (!string.IsNullOrEmpty(axisStyleStr))
                    {
                        axisStyle += axisIndex + "," + axisStyleStr + "|";
                    }

                    axisIndex++;
                }

                axisTypes = axisTypes.TrimEnd(",".ToCharArray());
                axisLabels = axisLabels.TrimEnd("|".ToCharArray());
                axisLabelPositions = axisLabelPositions.TrimEnd("|".ToCharArray());
                axisRange = axisRange.TrimEnd("|".ToCharArray());
                axisStyle = axisStyle.TrimEnd("|".ToCharArray());

                UrlElements.Enqueue(axisTypes);
                UrlElements.Enqueue(axisLabels);
                UrlElements.Enqueue(axisLabelPositions);
                UrlElements.Enqueue(axisRange);
                UrlElements.Enqueue(axisStyle);
            }

            // Grid
            if (gridSet)
            {
                UrlElements.Enqueue(GetGridUrlElement());
            }

            // Markers
            var markersString = "chm=";
            if (shapeMarkers.Count > 0)
            {
                markersString += GetShapeMarkersUrlElement() + "|";
            }

            if (rangeMarkers.Count > 0)
            {
                markersString += GetRangeMarkersUrlElement() + "|";
            }

            if (fillAreas.Count > 0)
            {
                markersString += GetFillAreasUrlElement() + "|";
            }

            if (shapeMarkers.Count > 0 || rangeMarkers.Count > 0 || fillAreas.Count > 0)
            {
                UrlElements.Enqueue(markersString.TrimEnd("|".ToCharArray()));
            }
        }

        private string GenerateUrlString()
        {
            var url = string.Empty;

            url += ApiBase;
            url += UrlElements.Dequeue();

            while (UrlElements.Count > 0)
            {
                url += "&" + UrlElements.Dequeue();
            }

            return url;
        }
    }
}