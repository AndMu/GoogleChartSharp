using System;
using NUnit.Framework;
using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart.Tests.Helpers
{
    [TestFixture]
    public class DatasetHelperTests
    {
        private DataPoint[] firstData;

        private DataPoint[] secondData;

        private LineChart chart;

        [SetUp]
        public void Setup()
        {
            chart = new LineChart(10, 10);
            firstData = new[]
            {
                new DataPoint { Date = new DateTime(2012, 02, 23), Value = 2 },
                new DataPoint { Date = new DateTime(2012, 02, 23), Value = 3 },
                new DataPoint { Date = new DateTime(2012, 02, 25), Value = 2 }
            };

            secondData = new[]
            {
                new DataPoint { Date = new DateTime(2012, 02, 21), Value = 2 },
                new DataPoint { Date = new DateTime(2012, 02, 25), Value = 2 }
            };
        }

        [Test]
        public void TestDay()
        {
            var instance = new DatasetHelper(new DayOfWeekSampling());
            instance.AddSeries("One", firstData);
            instance.AddSeries("Two", secondData);
            instance.Populate(chart);
            Assert.AreEqual(2, chart.TotalRows);
        }

        [Test]
        public void TestHour()
        {
            var instance = new DatasetHelper(new HourSampling());
            instance.AddSeries("One", firstData);
            instance.AddSeries("Two", secondData);
            instance.Populate(chart);
            Assert.AreEqual(2, chart.TotalRows);
        }
    }
}
