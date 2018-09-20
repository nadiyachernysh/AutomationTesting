using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TalTrackAutomation.Pages.Base;
using TalTrackAutomation;

namespace TalTrackAutomation
{
    public class LoginPage : BasePage
    {
        protected TextBox emailTalTrack;
        protected Button signInTalTrack;
        private TextBox emailMicroSoft;
        private TextBox passwordMicroSoft;
        private Button signInMicroSoft;
        private Button _staySignedInNo;
        private Button acceptMicroSoft;
        private Button _settings;
        private Button _logOut;
        private Browser browser;
        private string _username;
        private string _password;

        public LoginPage(Browser browser) : base(browser)
        {
            this.emailTalTrack = new TextBox(browser, By.Id("email"));
            this.signInTalTrack = new Button(browser, By.ClassName("btn-default"));
            this.emailMicroSoft = new TextBox(browser, By.Id("cred_userid_inputtext"));
            this.passwordMicroSoft = new TextBox(browser, By.Id("i0118"));
            this.signInMicroSoft = new Button(browser, By.Id("idSIButton9"));
            _staySignedInNo = new Button(browser, By.Id("idBtn_Back"));
            this.acceptMicroSoft = new Button(browser, By.Id("cred_accept_button"));
            _settings = new Button(browser, By.ClassName("settings-icon"));
            _logOut = new Button(browser, By.ClassName("logout"));
            this.browser = browser;
        }
        public void GoTo()
        {
            this.browser.Goto("login");            

        }

        public void CopyCreds()
        {
            string path = @"C:\Users\ncherny\Credentials.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    _username = sr.ReadLine();
                    _password = sr.ReadLine();                                        
                }
            }
            catch (Exception e)
            {
                Logger.Log.Error(e.Message);                
            }

        }

        public void Login()
        {
            this.emailTalTrack.TypeText(_username);
            browser.Pause(1);
            this.signInTalTrack.Click();
            browser.WaitForPageToBeFullyLoaded();
            browser.WaitForElementClickable(By.Id("i0118"));            
            this.passwordMicroSoft.Click();
            browser.WaitForPageToBeFullyLoaded();
            this.passwordMicroSoft.TypeText(_password);
            browser.Pause(1);
            browser.WaitForElementClickable(By.Id("idSIButton9"));
            this.signInMicroSoft.Click();
            _staySignedInNo.Click();
            browser.WaitForPageToBeFullyLoaded();
            browser.Pause(1);
        }

        public static LoginCommand LoginAs (string userName)
        {
            return new LoginCommand(userName);
        }

        public void Logout()
        {
            _settings.Click();
            _logOut.Click();
            browser.Pause(1);          
        }
    }

    public class LoginCommand
    {
        private string password;
        private readonly string userName;

        public LoginCommand (string userName)
        {
            this.userName = userName;
        }
        
        public LoginCommand WithPassword (string password)
        {
            this.password = password;
            return this;
        }
    }

}
