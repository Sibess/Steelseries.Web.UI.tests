using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class ArctisProWireless : Headsets
    {
        public ArctisProWireless(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Watch product film']")]
        private IWebElement WatchProductFilmButton { get; set; }
        
        public void ClickWatchProductFilmButton()
        {
            ClickElement(WatchProductFilmButton, "Watch Product Film Button");
        }
    }
}