using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebUI.pages
{
	public class CatalogPage : BasePage
	{
		public CatalogPage(IWebDriver driver) : base(driver)
		{
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "navbar-brand")]
        private IWebElement title;

        public IWebElement getTitle()
        {
            waitForElementToBePreset(By.ClassName("navbar-brand"));
            return title;
        }
    }
}

