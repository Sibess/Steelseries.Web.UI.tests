using OpenQA.Selenium;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class ExternalPages : BasePageObject
    {
        public ExternalPages(IWebDriver driver) : base(driver)
        {
        }
        
        public Youtube Youtube => new Youtube(Driver);
    }
}