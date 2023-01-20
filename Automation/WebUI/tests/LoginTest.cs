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
        public void SeleniumFirstTest1()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.getUsername().SendKeys("rahulshettyacademy");
            loginPage.getPassword().SendKeys("learning");
            loginPage.getSignButton().Click();

            CatalogPage catalogPage = new CatalogPage(driver);
            
            Assert.That(catalogPage.getTitle().Text, Is.EqualTo("ProtoCommerce"));
        }
    }
}