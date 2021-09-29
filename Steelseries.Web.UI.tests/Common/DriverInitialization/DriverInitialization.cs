using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Steelseries.Web.UI.tests.Common;
using Steelseries.Web.UI.tests.Util;

namespace Steelseries.Web.UI.tests
{
    public class DriverInitialization
    {
        public IWebDriver InitializeDriver()
        {
            IWebDriver driver;

            switch (GlobalRunSettings.BrowserName)
            {
                case BrowserName.Chrome:
                    var chromeOptions = new ChromeOptions
                    {
                        PageLoadStrategy = PageLoadStrategy.Normal,
                        AcceptInsecureCertificates = true,
                        UnhandledPromptBehavior = UnhandledPromptBehavior.Accept
                    };
                    chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);
                    chromeOptions.AddUserProfilePreference("download.default_directory", FileHelperDownload.GetDownloadsFolderPath());
                    chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
                    chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
                    chromeOptions.AddArgument("no-sandbox");
                    chromeOptions.AddArgument("lang=en");
                    driver = new ChromeDriver(chromeOptions);
                    break;
                default:
                    throw new Exception($"{GlobalRunSettings.BrowserName} driver can not be initialized");
            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return driver;
        }
    }
}
