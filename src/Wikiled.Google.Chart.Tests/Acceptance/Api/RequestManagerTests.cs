using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NUnit.Framework;
using Wikiled.Google.Chart.Api;

namespace Wikiled.Google.Chart.Tests.Acceptance.Api
{
    [TestFixture]
    public class RequestManagerTests
    {
        private RequestManager instance;

        [SetUp]
        public void SetUp()
        {
            instance = CreateManager();
        }

        [Test]
        public async Task Construct()
        {
            float[] line1 = { 5, 10, 50, 34, 10, 25 };
            float[] line2 = { 15, 20, 100, 44, 20, 35 };

            List<float[]> dataset = new List<float[]>();
            dataset.Add(line1);
            dataset.Add(line2);

            LineChart lineChart = new LineChart(500, 300);
            lineChart.SetTitle("Line Color And Legend Test", "0000FF", 14);
            lineChart.SetData(dataset);
            lineChart.AddRangeMarker(new RangeMarker(RangeMarkerType.Horizontal, "000000", 0.499, 0.501));
            lineChart.AddLineStyle(new LineStyle(5, 0, 0));
            lineChart.AddLineStyle(new LineStyle(5, 0, 0));

            List<string> days = new List<string>();
            var today = DateTime.Today;
            for (int i = 0; i < 5; i++)
            {
                days.Add(today.AddDays(-4 + i).DayOfWeek.ToString());
            }

            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom, days.ToArray()));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left).SetRange(-2, 2));

            lineChart.SetDatasetColors(new[] { "FF0000", "00FF00" });
            lineChart.SetLegend(new[] { "AMD", "MU" });

            var data = await instance.GetImage(lineChart);
            Assert.Greater(data.Length, 5000);
            File.WriteAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, "image.jpg"), data);
        }

        private RequestManager CreateManager()
        {
            return new RequestManager();
        }
    }
}
