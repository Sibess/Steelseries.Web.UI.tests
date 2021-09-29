using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class Engine : Home
    {
        public Engine(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[@class='button button--solid button--white js-gg-download-button']")]
        private IWebElement DownloadWindowsButton { get; set; }

        public void ClickDownloadWindowsButton()
        {
            ClickElement(DownloadWindowsButton, "Download Windows Button");
        }
    }
}