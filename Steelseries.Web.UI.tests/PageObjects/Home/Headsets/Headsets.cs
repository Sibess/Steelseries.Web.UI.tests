using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Steelseries.Web.UI.tests.PageObjects
{
    public class Headsets : BasePageObject
    {
        public Headsets(IWebDriver driver) : base(driver)
        {
        }

        public ArctisProWireless ArctisProWireless => new ArctisProWireless(Driver);

        [FindsBy(How = How.XPath, Using = "//a[@href='/gaming-headsets/arctis-pro-wireless?color=white']//div[@class='catalog-list-product__content']//div[@class='catalog-list-product__name h--200 OneLinkNoTx']")]
        private IWebElement ArticProWirelessWhiteItem { get; set; } 

        public void ClickArctisProWirelessWhiteItem()
        {
            ClickElement(ArticProWirelessWhiteItem, "Artic Pro Wireless White Item");
        }
    }
}