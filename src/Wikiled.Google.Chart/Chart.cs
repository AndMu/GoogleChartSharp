using System;
using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    /// <summary>
    /// Base type for all charts.
    /// </summary>
    public abstract class Chart : IChart
    {
        private const string ApiBase = "http://chart.apis.google.com/chart?";

        internal Queue<string> UrlElements { get; } = new Queue<string>();

        /// <summary>
        /// Create a chart
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        protected Chart(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Chart width in pixels.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Chart height in pixels.
        /// </summary>
        public int Height { get; set; }

        private string data;

        /// <summary>
        /// Set chart to use single integer dataset
        /// </summary>
        /// <param name="data"></param>
        public void SetData(int[] data)
        {
            this.data = ChartData.Encode(data);
        }

        /// <summary>
        /// Set chart to use integer dataset collection
        /// </summary>
        /// <param name="data"></param>
        public void SetData(ICollection<int[]> data)
        {
            this.data = ChartData.Encode(data);
        }

        /// <summary>
        /// Set chart to use single float dataset
        /// </summary>
        /// <param name="data"></param>
        public void SetData(float[] data)
        {
            this.data = ChartData.Encode(data);
        }

        /// <summary>
        /// Set chart to use float dataset collection
        /// </summary>
        /// <param name="data"></param>
        public void SetData(ICollection<float[]> data)
        {
            this.data = ChartData.Encode(data);
        }

		/// <summary>
		/// Set chart to use single long dataset
		/// </summary>
		/// <param name="data"></param>
		public void SetData(long[] data)
		{
			this.data = ChartData.Encode(data);
		}

		/// <summary>
		/// Set chart to use long dataset collection
		/// </summary>
		/// <param name="data"></param>
		public void SetData(ICollection<long[]> data)
		{
			this.data = ChartData.Encode(data);
		}

        private string title;
        private string titleColor;

        /// <summary>
        /// Set chart title using default color and font size
        /// </summary>
        /// <param name="title">chart title text</param>
        public void SetTitle(string title)
        {
            string urlTitle = title.Replace(" ", "+");
            urlTitle = urlTitle.Replace(Environment.NewLine, "|");
            this.title = urlTitle;
        }

        /// <summary>
        /// Set chart title using default font size
        /// </summary>
        /// <param name="title">chart title text</param>
        /// <param name="color">chart title color an RRGGBB format hexadecimal number</param>
        public void SetTitle(string title, string color)
        {
            SetTitle(title);
            titleColor = color;
        }

        /// <summary>
        /// Set chart title
        /// </summary>
        /// <param name="title">chart title text</param>
        /// <param name="color">chart title color an RRGGBB format hexadecimal number</param>
        /// <param name="fontSize">chart title font size in pixels</param>
        public void SetTitle(string title, string color, int fontSize)
        {
            SetTitle(title);
            titleColor = color + "," + fontSize;
        }

        private string[] datasetColors;

        /// <summary>
        /// Set the color for each dataset, match colors to datasets by
        /// specifying them in the same order the datasets were added to the
        /// chart.
        /// </summary>
        /// <param name="datasetColors">an array of RRGGBB format hexadecimal numbers</param>
        public void SetDatasetColors(string[] datasetColors)
        {
            this.datasetColors = datasetColors;
        }

        readonly List<SolidFill> solidFills = new List<SolidFill>();

        readonly List<LinearGradientFill> linearGradientFills = new List<LinearGradientFill>();

        readonly List<LinearStripesFill> linearStripesFills = new List<LinearStripesFill>();

        /// <summary>
        /// Add a solid fill to this chart.
        /// </summary>
        /// <param name="solidFill"></param>
        public void AddSolidFill(SolidFill solidFill)
        {
            solidFills.Add(solidFill);
        }

        /// <summary>
        /// Add a linear gradient fill to this chart.
        /// </summary>
        /// <param name="linearGradientFill"></param>
        public void AddLinearGradientFill(LinearGradientFill linearGradientFill)
        {
            linearGradientFills.Add(linearGradientFill);
        }

        /// <summary>
        /// Add a linear stripes fill to this chart.
        /// </summary>
        /// <param name="linearStripesFill"></param>
        public void AddLinearStripesFill(LinearStripesFill linearStripesFill)
        {
            linearStripesFills.Add(linearStripesFill);
        }

        bool gridSet = false;
        private float gridXAxisStepSize = -1;
        private float gridYAxisStepSize = -1;
        private float gridLengthLineSegment = -1;
        private float gridLengthBlankSegment = -1;

        /// <summary>
        /// Add a grid to the chart using default line segment and blank line segment length.
        /// </summary>
        /// <param name="xAxisStepSize">Space between x-axis grid lines in relation to axis range.</param>
        /// <param name="yAxisStepSize">Space between y-axis grid lines in relation to axis range.</param>
        public void SetGrid(float xAxisStepSize, float yAxisStepSize)
        {
            ChartType chartType = GetChartType();
            if (!(chartType == ChartType.LineChart || chartType == ChartType.ScatterPlot))
            {
                throw new InvalidFeatureForChartTypeException();
            }

            gridXAxisStepSize = xAxisStepSize;
            gridYAxisStepSize = yAxisStepSize;
            gridLengthLineSegment = -1;
            gridLengthBlankSegment = -1;
            gridSet = true;
        }

        /// <summary>
        /// Add a grid to the chart.
        /// </summary>
        /// <param name="xAxisStepSize">Space between x-axis grid lines in relation to axis range.</param>
        /// <param name="yAxisStepSize">Space between y-axis grid lines in relation to axis range.</param>
        /// <param name="lengthLineSegment">Length of each line segment in a grid line</param>
        /// <param name="lengthBlankSegment">Length of each blank segment in a grid line</param>
        public void SetGrid(float xAxisStepSize, float yAxisStepSize, float lengthLineSegment, float lengthBlankSegment)
        {
            ChartType chartType = GetChartType();
            if (!(chartType == ChartType.LineChart || chartType == ChartType.ScatterPlot))
            {
                throw new InvalidFeatureForChartTypeException();
            }

            gridXAxisStepSize = xAxisStepSize;
            gridYAxisStepSize = yAxisStepSize;
            gridLengthLineSegment = lengthLineSegment;
            gridLengthBlankSegment = lengthBlankSegment;
            gridSet = true;
        }

        private string GetGridUrlElement()
        {
            if (gridXAxisStepSize != -1 && gridYAxisStepSize != -1)
            {
                string s = $"chg={gridXAxisStepSize.ToString()},{gridYAxisStepSize.ToString()}";
                if (gridLengthLineSegment != -1 && gridLengthBlankSegment != -1)
                {
                    s += "," + gridLengthLineSegment.ToString() + "," + gridLengthBlankSegment.ToString();
                }
                return s;
            }
            return null;
        }

        readonly List<ShapeMarker> shapeMarkers = new List<ShapeMarker>();

        readonly List<RangeMarker> rangeMarkers = new List<RangeMarker>();

        readonly List<FillArea> fillAreas = new List<FillArea>();

        /// <summary>
        /// Add a fill area to the chart. Fill areas are fills between / under lines.
        /// </summary>
        /// <param name="fillArea"></param>
        public void AddFillArea(FillArea fillArea)
        {
            fillAreas.Add(fillArea);
        }

        /// <summary>
        /// Add a shape marker to the chart. Shape markers are used to call attention to a data point on the chart.
        /// </summary>
        /// <param name="shapeMarker"></param>
        public void AddShapeMarker(ShapeMarker shapeMarker)
        {
            shapeMarkers.Add(shapeMarker);
        }

        /// <summary>
        /// Add a range marker to the chart. Range markers are colored bands on the chart.
        /// </summary>
        /// <param name="rangeMarker"></param>
        public void AddRangeMarker(RangeMarker rangeMarker)
        {
            rangeMarkers.Add(rangeMarker);
        }

        private string GetFillAreasUrlElement()
        {
            string s = string.Empty;
            foreach (FillArea fillArea in fillAreas)
            {
                s += fillArea.GetUrlString() + "|";
            }
            return s.TrimEnd("|".ToCharArray());
        }

        private string GetShapeMarkersUrlElement()
        {
            string s = string.Empty;
            foreach (ShapeMarker shapeMarker in shapeMarkers)
            {
                s += shapeMarker.GetUrlString() + "|";
            }
            return s.TrimEnd("|".ToCharArray());
        }

        private string GetRangeMarkersUrlElement()
        {
            string s = string.Empty;
            foreach (RangeMarker rangeMarker in rangeMarkers)
            {
                s += rangeMarker.GetUrlString() + "|";
            }
            return s.TrimEnd("|".ToCharArray());
        }

        readonly List<ChartAxis> axes = new List<ChartAxis>();

        readonly List<string> legendStrings = new List<string>();

        /// <summary>
        /// Set chart legend
        /// </summary>
        /// <param name="strs">legend labels</param>
        public virtual void SetLegend(string[] strs)
        {
            foreach (string s in strs)
            {
                legendStrings.Add(s);
            }
        }

        /// <summary>
        /// Add an axis to the chart
        /// </summary>
        /// <param name="axis"></param>
        public void AddAxis(ChartAxis axis)
        {
            axes.Add(axis);
        }

        /// <summary>
        /// Return the chart api url for this chart
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            CollectUrlElements();
            return GenerateUrlString();
        }

        /// <summary>
        /// Returns the api chart identifier for the chart
        /// </summary>
        /// <returns></returns>
        protected abstract string UrlChartType();
        protected abstract ChartType GetChartType();

        /// <summary>
        /// Collect all the elements that will be used in the chart url
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
                string s = "chco=";
                foreach (string color in datasetColors)
                {
                    s += color + ",";
                }
                UrlElements.Enqueue(s.TrimEnd(",".ToCharArray()));
            }

            // Fills
            string fillsString = "chf=";
            if (solidFills.Count > 0)
            {
                foreach (SolidFill solidFill in solidFills)
                {
                    fillsString += solidFill.GetUrlString() + "|";
                }
            }
            if (linearGradientFills.Count > 0)
            {
                foreach (LinearGradientFill linearGradient in linearGradientFills)
                {
                    fillsString += linearGradient.GetUrlString() + "|";
                }
            }
            if (linearStripesFills.Count > 0)
            {
                foreach (LinearStripesFill linearStripesFill in linearStripesFills)
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
                string s = "chdl=";
                foreach (string str in legendStrings)
                {
                    s += str + "|";
                }
                UrlElements.Enqueue(s.TrimEnd("|".ToCharArray()));
            }

            // Axes
            if (axes.Count > 0)
            {
                string axisTypes = "chxt=";
                string axisLabels = "chxl=";
                string axisLabelPositions = "chxp=";
                string axisRange = "chxr=";
                string axisStyle = "chxs=";

                int axisIndex = 0;
                foreach (ChartAxis axis in axes)
                {
                    axisTypes += axis.UrlAxisType() + ",";
                    axisLabels += axisIndex.ToString() + ":" + axis.UrlLabels();
                    string labelPositions = axis.UrlLabelPositions();
                    if (! String.IsNullOrEmpty(labelPositions))
                    {
                        axisLabelPositions += axisIndex.ToString() + "," + labelPositions + "|";
                    }
                    string axisRangeStr = axis.UrlRange();
                    if (!String.IsNullOrEmpty(axisRangeStr))
                    {
                        axisRange += axisIndex.ToString() + "," + axisRangeStr + "|";
                    }
                    string axisStyleStr = axis.UrlAxisStyle();
                    if (!String.IsNullOrEmpty(axisStyleStr))
                    {
                        axisStyle += axisIndex.ToString() + "," + axisStyleStr + "|";
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
            string markersString = "chm=";
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
            string url = string.Empty;

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
