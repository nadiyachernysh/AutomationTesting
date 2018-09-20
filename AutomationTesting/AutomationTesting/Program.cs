using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\ncherny\Libraries\");
            driver.Url = "http://omobonoappraisalappstage.azurewebsites.net/login";

            var logInBox = driver.FindElement(By.Id("email"));
            logInBox.SendKeys("ncherny@taltrack.com");
            
            var getStarted = driver.FindElement(By.ClassName("btn-default"));
            getStarted.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var loginMs = driver.FindElement(By.Id("cred_userid_inputtext"));
            loginMs.SendKeys("ncherny@taltrack.com");
            loginMs.Submit();

            var passMs = driver.FindElement(By.Id("cred_password_inputtext"));
            passMs.SendKeys("2Wsxzaq1@");
            passMs.Submit();

            //var signInMs = driver.FindElement(By.Id("cred_sign_in_button"));
            //signInMs.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            var acceptMs = driver.FindElement(By.Id("cred_accept_button"));
            acceptMs.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            var menu = driver.FindElement(By.ClassName("nav-pills"));
            var team = menu.FindElement(By.ClassName("my-team"));
            team.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var teamMembers = driver.FindElement(By.ClassName("users-list"));

            var selectElement = new SelectElement(teamMembers);
           
            var member = teamMembers.FindElements(By.TagName("a"))[1];
            member.Click();



        }
    }
}
