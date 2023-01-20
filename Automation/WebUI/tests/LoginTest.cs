using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebUI.pages;

namespace WebUI
{
    public class LoginTest : BaseTest
    {
        [Test]
        [TestCase("rahulshettyacademy", "learning")]
        public void shouldSuccessfullyLogin(String username, String password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.getUsername().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getSignButton().Click();

            CatalogPage catalogPage = new CatalogPage(driver);

            Assert.That(catalogPage.getTitle().Text, Is.EqualTo("ProtoCommerce"));
        }


        [Test, TestCaseSource(nameof(AddTestDataConfig))]
        public void shouldFailLogin(String username, String password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.getUsername().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getSignButton().Click();
                        
            Assert.That(loginPage.getAlertError().Text, Is.EqualTo("Incorrect username/password."));
        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData("rahulshetty", "learning");
            yield return new TestCaseData("rahulshettyacademy", "lear");
        }
    }
}