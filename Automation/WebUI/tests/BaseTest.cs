using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace WebUI
{
	public class BaseTest 
	{
       
        protected ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void Setup()
        {
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Url = ConfigurationManager.AppSettings["url"];
        }

        private void InitBrowser(string browserName)
        {          
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;
                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Value.Close();
            driver.Value.Quit();
        }
    }
}

