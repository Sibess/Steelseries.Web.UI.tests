using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using Steelseries.Web.UI.tests.Common;
using Steelseries.Web.UI.tests.PageObjects;
using System;

namespace Steelseries.Web.UI.tests.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testsettings.json").Build();
        protected static Home Home { get; set; }
        protected static ExternalPages ExternalPages { get; set; }

        [SetUp]
        public void StartDriver()
        {
            DriverInitialization driverInitialization = new DriverInitialization();
            Driver = driverInitialization.InitializeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(GlobalRunSettings.StartUrl);
            Home = new Home(Driver);
            ExternalPages = new ExternalPages(Driver);
        }

        [OneTimeSetUp]
        public static void InitializeAssembly()
        {
            InitializeRunSettings();
        }

        private static void InitializeRunSettings()
        {
            GlobalRunSettings.StartUrl = TestConfiguration["Settings:StartUrl"];
            GlobalRunSettings.BrowserName = (BrowserName)Enum.Parse(typeof(BrowserName),TestConfiguration["Settings:BrowserName"]);
            GlobalRunSettings.TimeoutSeconds = int.Parse(TestConfiguration["Settings:TimeoutSeconds"]);
        }
        
       [TearDown]
        public void QuitDriver()
        {
            Driver?.Quit();
        }
    }
}
