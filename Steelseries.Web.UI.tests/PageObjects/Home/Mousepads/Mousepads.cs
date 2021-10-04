using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class Mousepads : BasePageObject
    {
        public Mousepads(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='faceted-product-list__list']//div[2]//div[1]//div[1]//div[1]//div[1]//ul[1]//li[5]//a[1]//div[1]")]
        private IWebElement MousePadSizeIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='faceted-product-list__list']//div[2]//div[1]//div[1]//div[1]//div[2]//button[2]")]
        private IWebElement ChevronRight { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/gaming-mousepads/qck-prism-series?size=xl']//figure[@class='catalog-list-product__image ']//img")]
        private IWebElement MousepadlItemIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip__inner'][normalize-space()='XL']")]
        private IWebElement XlTooltip { get; set; }

        public void HoverOverMousePadSizeXl()
        {
            MoveToElement(MousePadSizeIcon, "MousePad size icon");
        }

        public void ClickChevronRight()
        {
            ClickElement(ChevronRight, "Chevron right icon");
        }

        public void HoverOverMousepadlItemIcon()
        {
            MoveToElement(MousepadlItemIcon, "Mousepad lItem Icon");
        }

        public bool IsXlTooltipDisplayed()
        {
            return IsElementDisplayed(XlTooltip, "Xl Tooltip");
        }
    }
}
