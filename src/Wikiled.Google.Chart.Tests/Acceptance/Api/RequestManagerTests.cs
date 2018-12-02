using System.Collections.Generic;
using System.IO;
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
            int[] line1 = { 5, 10, 50, 34, 10, 25 };
            int[] line2 = { 15, 20, 60, 44, 20, 35 };

            List<int[]> dataset = new List<int[]>();
            dataset.Add(line1);
            dataset.Add(line2);

            LineChart lineChart = new LineChart(250, 150);
            lineChart.SetTitle("Single Dataset Per Line", "0000FF", 14);
            lineChart.SetData(dataset);
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Bottom));
            lineChart.AddAxis(new ChartAxis(ChartAxisType.Left));
            var data = await instance.GetImage(lineChart).ConfigureAwait(false);
            Assert.Greater(data.Length, 5000);
            File.WriteAllBytes("image.jpg", data);
        }

        private RequestManager CreateManager()
        {
            return new RequestManager();
        }
    }
}
