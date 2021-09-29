using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class BasePageObject
    {
        protected IWebDriver Driver { get; set; }
        protected IJavaScriptExecutor JavaScriptExecutor { get; set; }
        protected WebDriverWait Wait { get; set; }

        public BasePageObject(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
            Driver = driver;
            JavaScriptExecutor = (IJavaScriptExecutor)Driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalRunSettings.TimeoutSeconds));
            PageFactory.InitElements(this,
                new RetryingElementLocator(driver, TimeSpan.FromSeconds(5)));
        }

        protected void TypeInto(IWebElement element, string text, string fieldDescription)
        {

            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        protected void ClickElement(IWebElement element, string description)
        {


            ScrollIntoViewDefault(element);
            element.Click();

        }
        protected void ClickElement(By by, string description)
        {
            IWebElement element;
            element = Driver.FindElement(by);

            ScrollIntoViewDefault(element);
            element.Click();
        }
        protected bool IsElementDisplayed(IWebElement element, string description)
        {
            try
            {
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        protected bool IsElementDisplayed(By by, string description)
        {
            IWebElement element;
            try
            {
                element = Driver.FindElement(by);
                return element.Displayed;
            }
            catch
            {
                return false;
            }
        }
        protected void ScrollIntoViewDefault(IWebElement element)
        {
            JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        protected void MoveToElement(IWebElement element, string description)
        {

            var actions = new Actions(Driver);
            actions.MoveToElement(element).Perform();
        }

        protected void MoveToElement(By by, string description)
        {
            IWebElement element;
            var actions = new Actions(Driver);
            element = Driver.FindElement(by);
            actions.MoveToElement(element).Perform();
        }
    }
}
