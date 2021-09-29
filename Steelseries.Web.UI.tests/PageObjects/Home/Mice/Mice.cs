using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class Mice : BasePageObject
    {
        public Mice(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='facet-content-grip-style']/ul/li[2]/a/div[@class='constraint__indicator']")]
        private IWebElement FingertipCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "js-sorting-select")]
        private IWebElement SortByDropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//option[@value='price-low-to-high']")]
        private IWebElement PriceLowToHighOption { get; set; }

        public void CheckFingertipCheckbox()
        {
            ClickElement(FingertipCheckbox, "Fingertip Checkbox");
        }

        public bool IsRival650WirelessItemDisplayed()
        {
            return IsElementDisplayed(By.XPath("//div[normalize-space()='Rival 650 Wireless']"), "Rival 650 Wireless Item");
        }

        public bool IsRival3ItemDisplayed()
        {
            return IsElementDisplayed(By.XPath("//div[normalize-space()='Rival 3']"), "Rival 3 Item");
        }

        public void ClickSortByDropdown()
        {
            ClickElement(SortByDropdown, "Sort By Dropdown");
        }

        public void ClickPriceLowToHighOption()
        {
            ClickElement(PriceLowToHighOption, "Price Low To High Option");
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//body/main[@id='main']/div[1]/div[1]/div[3]/div[2]/div[1]"))); // test crashes with //div[@class='catalog-list'] Xpath
        }

        public bool IsPriceLowToHighOptionSelected()
        {
            return PriceLowToHighOption.Selected;
        }

        public void ClickRemoveFilterIcon(string filterName)
        {         
            ClickElement(By.XPath($"//a[@aria-label='Remove filter for {filterName}']//span//*[name()='svg']"), $"Remove {filterName} filter ");
        }
    }
}
