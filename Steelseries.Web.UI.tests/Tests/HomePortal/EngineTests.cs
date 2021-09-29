using NUnit.Framework;
using NUnit.Framework.Internal;
using Steelseries.Web.UI.tests.PageObjects;
using Steelseries.Web.UI.tests.Util;

namespace Steelseries.Web.UI.tests.Tests
{
    [TestFixture]
    public class EngineTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldDownloadWindowsEngine()
        {
            FileHelperDownload.ClearDownloadsFolder();

            Home.ClickSoftwareButton();
            Home.ClickHeaderButton("Engine");
            Home.Engine.ClickDownloadWindowsButton();

            FileHelperDownload.WaitUntilFileIsDownloaded("SteelSeriesGG8.0.0Setup.exe");
            Assert.IsTrue(FileHelperDownload.IsFileExists("SteelSeriesGG8.0.0Setup.exe"));
            FileHelperDownload.ClearDownloadsFolder();
            Assert.IsFalse(FileHelperDownload.IsFileExists("SteelSeriesGG8.0.0Setup.exe"));
        }
    }
}