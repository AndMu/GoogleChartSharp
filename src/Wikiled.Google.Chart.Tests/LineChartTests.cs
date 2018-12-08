using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Wikiled.Google.Chart;

namespace Wikiled.Google.Chart.Tests
{
    [TestFixture]
    public class LineChartTests
    {
        private LineChart instance;

        [SetUp]
        public void SetUp()
        {
            instance = CreateInstance();
        }

        [Test]
        public void SetData()
        {
            instance.SetData(new[] { 1 });
            Assert.AreEqual(1, instance.TotalSeries);
            Assert.AreEqual(1, instance.LowerBound);
            Assert.AreEqual(1, instance.UpperBound);

            instance.SetData(new[] { 1f });
            Assert.AreEqual(1, instance.TotalSeries);
            Assert.AreEqual(1, instance.LowerBound);
            Assert.AreEqual(1, instance.UpperBound);

            instance.SetData(new[] { 1l });
            Assert.AreEqual(1, instance.TotalSeries);
            Assert.AreEqual(1, instance.LowerBound);
            Assert.AreEqual(1, instance.UpperBound);

            var list = new List<int[]>();
            list.Add(new[] { -1 });
            list.Add(new[] { 1 });
            instance.SetData(list);
            Assert.AreEqual(2, instance.TotalSeries);
            Assert.AreEqual(-1, instance.LowerBound);
            Assert.AreEqual(1, instance.UpperBound);

            var listf = new List<float[]>();
            listf.Add(new[] { -1f });
            listf.Add(new[] { 2f });
            instance.SetData(listf);
            Assert.AreEqual(2, instance.TotalSeries);
            Assert.AreEqual(-1, instance.LowerBound);
            Assert.AreEqual(2, instance.UpperBound);

            var listl = new List<long[]>();
            listl.Add(new[] { 1l });
            listl.Add(new[] { 2l });
            instance.SetData(listl);
            Assert.AreEqual(1, instance.LowerBound);
            Assert.AreEqual(2, instance.UpperBound);
            Assert.AreEqual(2, instance.TotalSeries);
        }

        private LineChart CreateInstance()
        {
            return new LineChart(100, 100);
        }
    }
}
