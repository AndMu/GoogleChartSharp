using System.Collections.Generic;
using NUnit.Framework;

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

            instance.SetData(new[] { 1f });
            Assert.AreEqual(1, instance.TotalSeries);

            instance.SetData(new[] { 1L });
            Assert.AreEqual(1, instance.TotalSeries);

            var list = new List<int[]>();
            list.Add(new[] { -1 });
            list.Add(new[] { 1 });
            instance.SetData(list);
            Assert.AreEqual(2, instance.TotalSeries);

            var listf = new List<float[]>();
            listf.Add(new[] { -1f });
            listf.Add(new[] { 2f });
            instance.SetData(listf);
            Assert.AreEqual(2, instance.TotalSeries);

            var listl = new List<long[]>();
            listl.Add(new[] { 1L });
            listl.Add(new[] { 2L });
            instance.SetData(listl);
            Assert.AreEqual(2, instance.TotalSeries);
        }

        private LineChart CreateInstance()
        {
            return new LineChart(100, 100);
        }
    }
}
