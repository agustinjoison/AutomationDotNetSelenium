using System;
using System.Configuration;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace WebUI
{
	public class BaseTest 
	{
        protected ExtentReports extentReports;
        protected ExtentTest test;

        [OneTimeSetUp]
        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var htmlReporter = new ExtentHtmlReporter(projectDirectory + "//index.html");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("Host Name", "Localhost");
        }
       
        protected ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        [SetUp]
        public void SetupTest()
        {
            test = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
                DateTime time = DateTime.Now;
                String fileName = "ScreenShot_" + time.ToString("h_mm_ss") + ".png";
                test.Fail("Test failed", CaptureScreenShot(driver.Value, fileName));
                test.Log(Status.Fail, TestContext.CurrentContext.Result.StackTrace);
            }
            else if (status == TestStatus.Passed)
            {

            }
            extentReports.Flush();
            driver.Value.Quit();
        }

        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}

