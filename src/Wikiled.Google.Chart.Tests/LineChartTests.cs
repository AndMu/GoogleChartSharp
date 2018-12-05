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
            Assert.AreEqual(1, instance.TotalRows);

            instance.SetData(new[] { 1f });
            Assert.AreEqual(1, instance.TotalRows);

            instance.SetData(new[] { 1L });
            Assert.AreEqual(1, instance.TotalRows);

            var list = new List<int[]>();
            list.Add(new[] { 1 });
            list.Add(new[] { 1 });
            instance.SetData(list);
            Assert.AreEqual(2, instance.TotalRows);

            var listf = new List<float[]>();
            listf.Add(new[] { 1f });
            listf.Add(new[] { 1f });
            instance.SetData(listf);
            Assert.AreEqual(2, instance.TotalRows);

            var listl = new List<long[]>();
            listl.Add(new[] { 1L });
            listl.Add(new[] { 1L });
            instance.SetData(listl);
            Assert.AreEqual(2, instance.TotalRows);
        }

        private LineChart CreateInstance()
        {
            return new LineChart(100, 100);
        }
    }
}
