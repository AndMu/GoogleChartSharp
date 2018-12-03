using NUnit.Framework;

namespace Wikiled.Google.Chart.Tests
{
    [TestFixture]
    public class ColorsTests
    {
        [Test]
        public void GetColorByName()
        {
            Assert.AreEqual(Colors.Red, Colors.GetColorByName("RED"));
            Assert.AreEqual(Colors.Black, Colors.GetColorByName("black"));
        }

        [Test]
        public void GetColorByCode()
        {
            Assert.AreEqual(Colors.Red, Colors.GetColor(Colors.Red.Code));
            Assert.AreEqual(Colors.Black, Colors.GetColor(Colors.Black.Code));
        }
    }
}
