using Moq;
using NUnit.Framework;
using Wikiled.Google.Chart.Helpers;

namespace Wikiled.Google.Chart.Tests.Helpers
{
    [TestFixture]
    public class ChartExtensionTests
    {
        private Mock<IChart> chart;

        [SetUp]
        public void SetUp()
        {
            chart = new Mock<IChart>();
        }

        [TestCase(-0.4f, -0.2f, -1f, 1f)]
        [TestCase(-0.4f, 2f, -2f, 2f)]
        public void AdjustYScale(float lower, float upper, float expectedLower, float expectedUpper)
        {
            chart.Setup(item => item.UpperBound).Returns(lower);
            chart.Setup(item => item.LowerBound).Returns(upper);
            ChartAxis createdAxis = null;
            chart.Setup(item => item.AddAxis(It.IsAny<ChartAxis>())).Callback<ChartAxis>(axis => createdAxis = axis);
            chart.Object.AdjustYScale(2);
            Assert.AreEqual(expectedLower, createdAxis.LowerBound);
            Assert.AreEqual(expectedUpper, createdAxis.UpperBound);
        }
    }
}
