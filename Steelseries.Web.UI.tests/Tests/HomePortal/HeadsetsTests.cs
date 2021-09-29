using NUnit.Framework;
using NUnit.Framework.Internal;
using Steelseries.Web.UI.tests.PageObjects;

namespace Steelseries.Web.UI.tests.Tests
{
    [TestFixture]
    public class HeadsetsTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldPlayHeadsetProductFilm()
        {
            Home.HoverOverHeaderButton("Headsets");
            Home.ClickPcButton();
            Home.Headsets.ClickArctisProWirelessWhiteItem();
            Home.Headsets.ArctisProWireless.ClickWatchProductFilmButton();
            ExternalPages.Youtube.ClickPlayButton();
            Assert.IsTrue(ExternalPages.Youtube.IsVideoPlaying(), "Youtube video was not playing");
        }
    }
}