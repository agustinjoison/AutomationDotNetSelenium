using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace WebUI
{
    public class LoginTest
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SeleniumFirstTest1()
        {
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.Id("signInBtn")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("navbar-brand")));

            Assert.That(driver.FindElement(By.ClassName("navbar-brand")).Text, Is.EqualTo("ProtoCommerce"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

    }
}