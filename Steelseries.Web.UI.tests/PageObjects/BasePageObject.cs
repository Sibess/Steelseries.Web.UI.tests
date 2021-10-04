using System;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Steelseries.Web.UI.tests.Common.Logging;
using System.Reflection;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class BasePageObject
    {
        protected IWebDriver Driver { get; set; }
        protected IJavaScriptExecutor JavaScriptExecutor { get; set; }
        protected WebDriverWait Wait { get; set; }

        private static readonly Logger Logger = Logger.Instance;

        public BasePageObject(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
            Driver = driver;
            JavaScriptExecutor = (IJavaScriptExecutor)Driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(GlobalRunSettings.TimeoutSeconds));
            PageFactory.InitElements(this,
                new RetryingElementLocator(driver, TimeSpan.FromSeconds(GlobalRunSettings.TimeoutSeconds)));
        }

        protected void TypeInto(IWebElement element, string text, string fieldDescription)
        {

            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        protected void ClickElement(IWebElement element, string description)
        {
            Logger.Info("Clicking element: " + description);
            try
            {
                ScrollIntoViewDefault(element);
                element.Click();
            }
            catch (Exception e)
            {
                if (e is TargetInvocationException)
                {
                    if (e.InnerException is ElementClickInterceptedException)
                    {
                        Logger.Error(e.InnerException, "Couldn't click the element.");
                        Logger.Info($"Trying to scroll into the view and click again element: '{description}'");
                        try
                        {
                            ScrollIntoView(element);
                            element.Click();
                        }
                        catch (Exception e2)
                        {
                            if (e2 is TargetInvocationException)
                            {
                                Logger.Fatal(e2.InnerException, "Couldn't click the element.");
                                throw;
                            }

                            Logger.Fatal(e2, "Couldn't click the element.");
                            throw;
                        }
                    }
                    else if (e.InnerException is ElementNotInteractableException)
                    {
                        Logger.Error(e.InnerException, "Couldn't click the element.");
                        Logger.Info(
                            $"Trying to wait until the element '{description}' is clickable and click it again");
                        try
                        {
                            element = Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                            element.Click();
                        }
                        catch (Exception e2)
                        {
                            if (e2 is TargetInvocationException)
                            {
                                Logger.Fatal(e2.InnerException, "Couldn't click the element.");
                                throw;
                            }

                            Logger.Fatal(e2, "Couldn't click the element.");
                            throw;
                        }
                    }
                    else if (e.InnerException is StaleElementReferenceException)
                    {
                        Logger.Error(e.InnerException, "Couldn't click the element.");
                        Logger.Info(
                            $"Trying to wait until the element '{description}' is clickable and click it again");
                        try
                        {
                            element = Wait.Until(ExpectedConditions.ElementToBeClickable(element));
                            element.Click();
                        }
                        catch (Exception e2)
                        {
                            if (e2 is TargetInvocationException)
                            {
                                Logger.Fatal(e2.InnerException, "Couldn't click the element.");
                                throw;
                            }

                            Logger.Fatal(e2, "Couldn't click the element.");
                            throw;
                        }
                    }
                    else
                    {
                        Logger.Fatal(e.InnerException, "Couldn't click the element.");
                        throw;
                    }
                }
                else
                {
                    Logger.Fatal(e, "Couldn't click the element.");
                    throw;
                }
            }
        }
        protected void ClickElement(By by, string description)
        {
            Logger.Info("Clicking element: " + description);
            IWebElement element;
            try
            {
                element = Wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (WebDriverTimeoutException te)
            {
                Logger.Fatal(te, $"Couldn't locate the element: {description} by '{by}'.");
                throw;
            }

            try
            {
                ScrollIntoViewDefault(element);
                element.Click();
            }
            catch (Exception e)
            {
                if (e is ElementClickInterceptedException)
                {
                    Logger.Error(e, "Couldn't click the element.");
                    Logger.Info($"Trying to scroll into the view and click again element: {description}");
                    try
                    {
                        element = Wait.Until(ExpectedConditions.ElementToBeClickable(by));
                        ScrollIntoView(element);
                        element.Click();
                    }
                    catch (Exception e2)
                    {
                        Logger.Fatal(e2, "Couldn't click the element.");
                        throw;
                    }
                }
                else if (e is StaleElementReferenceException)
                {
                    Logger.Error(e, "Couldn't click the element.");
                    Logger.Info($"Trying to wait until the element '{description}' is clickable and click it again");
                    try
                    {
                        element = Wait.Until(ExpectedConditions.ElementToBeClickable(by));
                        element.Click();
                    }
                    catch (Exception e2)
                    {
                        Logger.Fatal(e2, "Couldn't click the element.");
                        throw;
                    }
                }
                else
                {
                    Logger.Fatal(e, "Couldn't click the element.");
                    throw;
                }
            }
        }
        protected bool IsElementDisplayed(IWebElement element, string description)
        {
            Logger.Info($"Checking if the element is displayed: {description}");
            try
            {
                if (null != element && !element.Displayed)
                {
                    try
                    {
                        Logger.Warn(
                            "The element exists in DOM but is not displayed. Giving it the last chance(5 seconds).");
                        new WebDriverWait(Driver, TimeSpan.FromSeconds(5)).Until(eleDisplayed => element.Displayed);
                        Logger.Info($"The result is: {element.Displayed}");
                    }
                    catch (Exception)
                    {
                    }
                }
                return element.Displayed;
            }
            catch (TargetInvocationException tie)
            {
                if (tie.InnerException is StaleElementReferenceException) return false;

                Logger.Fatal(tie.InnerException, "Couldn't get the element state.");
                throw;
            }
            catch (WebDriverException wde)
            {
                if (wde is NoSuchElementException)
                {
                    return false;
                }

                Logger.Fatal(wde, "Couldn't get the element state.");
                throw;
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
        protected void ScrollIntoView(IWebElement element)
        {
            JavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        protected void MoveToElement(IWebElement element, string description)
        {
            Logger.Info("hovering over the element: " + description);
            try
            {
                var actions = new Actions(Driver);
                actions.MoveToElement(element).Perform();
            }
            catch (WebDriverException wde)
            {
                Logger.Fatal(wde, "Couldn't hover over the element.");
                throw;
            }
        }

        protected void MoveToElement(By by, string description)
        {
            Logger.Info("hovering over the element: " + description);
            try
            {
                IWebElement element;
                var actions = new Actions(Driver);
                element = Driver.FindElement(by);
                actions.MoveToElement(element).Perform();
            }
            catch (WebDriverException wde)
            {
                Logger.Fatal(wde, "Couldn't hover over the element.");
                throw;
            }
        }
    }
}
