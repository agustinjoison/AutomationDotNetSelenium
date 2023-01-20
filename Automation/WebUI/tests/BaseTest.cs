using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace WebUI
{
	public class BaseTest 
	{
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Url = ConfigurationManager.AppSettings["url"];
        }

        private void InitBrowser(string browserName)
        {          
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

