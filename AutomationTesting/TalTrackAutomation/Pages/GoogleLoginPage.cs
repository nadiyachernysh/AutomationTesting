using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTrackAutomation
{
    public class GoogleLoginPage : LoginPage
    {
        private TextBox _emailGoogle;
        private TextBox _passwordGoogle;
        private Button _signInGoogle;
        private Button _afterEmailGoogle;
        private Button _afterPasswordGoogle;
        private Browser _browser;

        public GoogleLoginPage(Browser browser) : base(browser)
        {
            _afterEmailGoogle = new Button(browser, By.ClassName("RveJvd"));//винести селектори в константи - бо в всіх вейтах треба писати їх повторно
            _passwordGoogle = new TextBox(browser, By.ClassName("whsOnd"));
            _afterPasswordGoogle = new Button(browser, By.Id("passwordNext"));
            _browser = browser;
            
        }

        public void GoogleLogin(string email, string password)
        {
            _browser.WaitForPageToBeFullyLoaded();
            emailTalTrack.TypeText(email);
            signInTalTrack.Click();
            _browser.WaitForPageToBeFullyLoaded();
            _browser.WaitForElementClickable(By.ClassName("RveJvd"));
            //var nextButtons = _browser.FindElements(By.Id("identifierNext"));
            //if (nextButtons.Count == 0)
            //{
            //    _browser.WaitForElementClickable(By.CssSelector("ul>li:nth-child(1)>div"));
            //    _browser.FindElement(By.CssSelector("ul>li:nth-child(1)>div")).Click();
            //}
            //else
            //{
            //    _browser.WaitForElementClickable(By.Id("identifierNext"));
            //    _afterEmailGoogle.Click();
            //}
            _afterEmailGoogle.Click();
            _browser.WaitForElementClickable(By.ClassName("whsOnd"));
            _passwordGoogle.TypeText(password);
            _browser.WaitForElementClickable(By.Id("passwordNext"));
            _afterPasswordGoogle.Click();
            _browser.WaitForPageToBeFullyLoaded();
        }
    }
}
