using System;
using NUnit.Framework;
using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart.Tests.Helpers
{
    [TestFixture]
    public class TimeSeriesTests
    {
        private DataPoint[] firstData;

        private DataPoint[] secondData;

        [SetUp]
        public void Setup()
        {
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
            var instance = new TimeSeries(new DayOfWeekSampling());
            instance.AddSeries("One", firstData);
            instance.AddSeries("Two", secondData);
            Assert.IsFalse(instance.IsGenerated);
            instance.Generate();
            Assert.IsTrue(instance.IsGenerated);
            Assert.AreEqual(2, instance.SeriesNames.Length);
            Assert.AreEqual(5, instance.Points[0].Length);
        }

        [Test]
        public void TestHour()
        {
            var instance = new TimeSeries(new HourSampling());
            instance.AddSeries("One", firstData);
            instance.AddSeries("Two", secondData);
            Assert.IsFalse(instance.IsGenerated);
            instance.Generate();
            Assert.IsTrue(instance.IsGenerated);
            Assert.AreEqual(2, instance.SeriesNames.Length);
            Assert.AreEqual(97, instance.Points[0].Length);
        }
    }
}
