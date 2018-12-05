using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NUnit.Framework;
using Wikiled.Google.Chart.Api;
using Wikiled.Google.Chart.Helpers;

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
            lineChart.SetTitle("Line Color And Legend Test", Colors.Black, 14);
            lineChart.SetData(dataset);
            lineChart.AddRangeMarker(new RangeMarker(RangeMarkerType.Horizontal, Colors.Black, 0.499, 0.501));
            lineChart.AddLineStyleAll(new LineStyle(5, 0, 0));

            List<string> days = new List<string>();
            var today = DateTime.Today;
            for (int i = 0; i < 5; i++)
            {
                days.Add(today.AddDays(-4 + i).DayOfWeek.ToString());
            }

            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom, days.ToArray()));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left).SetRange(-2, 2));

            lineChart.SetAutoColors();
            lineChart.SetLegend(new[] { "AMD", "MU" });

            var data = await instance.GetImage(lineChart);
            Assert.Greater(data.Length, 5000);
            File.WriteAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, "image.jpg"), data);
        }

        [Test]
        public async Task TimeSeries()
        {
            var chart = new LineChart(500, 200);
            var firstData = new[]
                        {
                            new DataPoint { Date = new DateTime(2012, 02, 23), Value = 20 },
                            new DataPoint { Date = new DateTime(2012, 02, 23), Value = 30 },
                            new DataPoint { Date = new DateTime(2012, 02, 25), Value = 25 }
                        };

            var secondData = new[]
                         {
                             new DataPoint { Date = new DateTime(2012, 02, 21), Value = 77 },
                             new DataPoint { Date = new DateTime(2012, 02, 25), Value = 48 }
                         };

            var dataSet = new DatasetHelper(new HourSampling());
            dataSet.AddSeries("One", firstData);
            dataSet.AddSeries("Two", secondData);
            dataSet.Populate(chart, (date, i) => i % 5 == 0);

            var data = await instance.GetImage(chart);
            Assert.Greater(data.Length, 5000);
            File.WriteAllBytes(Path.Combine(TestContext.CurrentContext.TestDirectory, "image.jpg"), data);
        }

        private RequestManager CreateManager()
        {
            return new RequestManager();
        }
    }
}
