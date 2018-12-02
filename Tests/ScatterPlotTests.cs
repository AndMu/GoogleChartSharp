using System.Collections.Generic;
using Wikiled.Google.Chart;

namespace Wikiled.Google.Charts.TestApp
{
    class ScatterPlotTests
    {
        public static string ScatterPlotTest()
        {
            int[] xData = { 10, 20, 30, 40, 50 };
            int[] yData = { 10, 20, 30, 40, 50 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(xData);
            dataset.Add(yData);

            ScatterPlot scatterPlot = new ScatterPlot(150, 150);
            scatterPlot.SetTitle("Scatter Plot");
            scatterPlot.SetData(dataset);

            scatterPlot.AddAxis(new ChartAxis(ChartAxisType.Left));
            scatterPlot.AddAxis(new ChartAxis(ChartAxisType.Bottom));

            return scatterPlot.GetUrl();
        }
    }
}
