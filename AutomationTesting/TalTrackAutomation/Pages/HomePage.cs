using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using TalTrackAutomation;
using TalTrackAutomation.Pages.Base;

namespace TalTrackAutomation
{
    public class HomePage : BasePage
    {
        private Button recentRating;
        private Browser _browser;
        private int _statisticValues;


        public HomePage(Browser browser) : base(browser)
        {
            _browser = browser;
        }

        public int PreviousRatedOwnGoalsCount;

        public int CurrentRatedOwnGoalsCount => int.Parse(_browser.FindElements(By.CssSelector(".value"))[1].Text);

        public void GoTo()
        {
            _browser.Goto("profile");
            _browser.WaitForPageToBeFullyLoaded();
        }

        public int GetRatedOwnGoalsCount()
        {
            _browser.WaitForPageToBeFullyLoaded();
            _browser.WaitForElementNonZero(By.ClassName("value-of"));
            return int.Parse(_browser.FindElements(By.CssSelector(".value"))[1].Text);
        }

        public int GetRatedTeamsGoalsCount()
        {
            _browser.WaitForElementNonZero(By.ClassName("value-of"));
            return int.Parse(_browser.FindElements(By.CssSelector(".value"))[4].Text);
        }

        public int GetOwnGoalsCount()
        {
            _browser.WaitForElementNonZero(By.ClassName("value-of"));
            return int.Parse(_browser.FindElements(By.CssSelector(".value-of"))[0].Text);
        }

        public string GetNameOfSender()
        {
            var fullName = _browser.FindElement(By.CssSelector(".personal-info-title")).Text;
            var name = fullName.Substring(0, fullName.IndexOf(" "));

            return name;
        }

        public string GetLastPublicPraise()
        {
            _browser.WaitForElementVisible(By.CssSelector(".recent-item:nth-child(1) .from-user p:first-child"));
            return _browser.FindElement(By.CssSelector(".recent-item:nth-child(1) .from-user p:first-child")).Text;
        }

        public string GetBodyOfLastPublicPraise()
        {
            _browser.WaitForElementVisible(By.CssSelector(".recent-item .from-user p:last-child"));
            var bodyOfLastPraise = _browser.FindElements(By.CssSelector(".recent-item .from-user p:last-child"))[0].Text;
            var checkWord = bodyOfLastPraise.Substring(0, bodyOfLastPraise.IndexOf(" "));
            return checkWord;
        }
    }
}
