using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace WebUI.pages
{
	public class LoginPage
	{
		public LoginPage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "username")]
		private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement sign;

		public IWebElement getUsername()
		{
			return username;
		}

        public IWebElement getPassword()
        {
            return password;
        }

		public IWebElement getSignButton()
		{
			return sign;
		}
    }
}

