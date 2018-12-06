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
            list.Add(new[] { 1 });
            list.Add(new[] { 1 });
            instance.SetData(list);
            Assert.AreEqual(2, instance.TotalSeries);

            var listF = new List<float[]>();
            listF.Add(new[] { 1f });
            listF.Add(new[] { 1f });
            instance.SetData(listF);
            Assert.AreEqual(2, instance.TotalSeries);

            var listL = new List<long[]>();
            listL.Add(new[] { 1L });
            listL.Add(new[] { 1L });
            instance.SetData(listL);
            Assert.AreEqual(2, instance.TotalSeries);
        }

        private LineChart CreateInstance()
        {
            return new LineChart(100, 100);
        }
    }
}
