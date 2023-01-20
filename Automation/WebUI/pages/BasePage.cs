using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebUI.pages
{
	public class BasePage
	{
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
		{
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void waitForElementToBePreset(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
	}
}

