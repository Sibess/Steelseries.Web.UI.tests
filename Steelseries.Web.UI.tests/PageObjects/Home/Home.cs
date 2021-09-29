using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class Home : BasePageObject
    {
        public Home(IWebDriver driver) : base(driver)
        {
        }

        public SignUp SignUp => new SignUp(Driver);
        public Mousepads Mousepads => new Mousepads(Driver);
        public Mice Mice => new Mice(Driver);
        public Headsets Headsets => new Headsets(Driver);
        public Engine Engine => new Engine(Driver);

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Sign up')]")]
        private IWebElement SignUpButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//nav[@aria-label='Products']//li[2]//ul[1]//li[2]//a[1]")]
        private IWebElement WirelessButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//nav[@aria-label='Products']//li[1]//ul[1]//li[1]")]
        private IWebElement PcButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='category-navigation__item-trigger js-nav-software']")]
        private IWebElement SoftwareButton { get; set; }
        
        public void ClickWirelessButton()
        {
            ClickElement(WirelessButton, "Wireless Button");
        }

        public void ClickSignUpButton()
        {
            ClickElement(SignUpButton, "Sign Up Button"); 
        }

        public void HoverOverHeaderButton(string headerButtonName)
        {
            MoveToElement(By.XPath($"//button[normalize-space()='{headerButtonName}']"), $"Hover over {headerButtonName} button");
        }

        public void ClickPcButton()
        {
            ClickElement(PcButton, "Pc Button");
        }
        public void ClickSoftwareButton()
        {
            ClickElement(SoftwareButton, "Software Button");
        }

        public void ClickHeaderButton(string headerButtonName)
        {
            ClickElement(By.XPath($"//li[@class='category-navigation__item']//a[normalize-space()='{headerButtonName}']"), $"Click {headerButtonName} button");
        }
    }
}