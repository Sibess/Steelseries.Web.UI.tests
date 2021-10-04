using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace Steelseries.Web.UI.tests.PageObjects
{
    public class Youtube : ExternalPages
    {
        public Youtube(IWebDriver driver) : base(driver)
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@class='mfp-iframe']"))); 
            PageFactory.InitElements(this,
                new RetryingElementLocator(driver, TimeSpan.FromSeconds(GlobalRunSettings.TimeoutSeconds))); 
        }

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Play']")]
        private IWebElement PlayButton { get; set; }

        public void ClickPlayButton()
        {
            ClickElement(PlayButton, "Youtube Play Button");
        }

        public bool IsVideoPlaying()
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='html5-video-player ytp-exp-bottom-control-flexbox ytp-title-enable-channel-logo ytp-embed ytp-embed-playlist ytp-large-width-mode playing-mode ytp-autohide']")));
            return IsElementDisplayed(By.XPath("//*[@class='html5-video-player ytp-exp-bottom-control-flexbox ytp-title-enable-channel-logo ytp-embed ytp-embed-playlist ytp-large-width-mode playing-mode ytp-autohide']"), "Youtube playing mode");
        }
    }
}