using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation.Pages.Base;

namespace TalTrackAutomation
{
    public class PraisePage : BasePage
    {
        private Browser _browser;
        private TextBox _searchForColleague;
        private Button _colleague;
        private TextBox _praiseText;
        private Button _valueCard;
        private Button _submit;
        private Button _cancel;
        private Button _viewLastSentPraise;
        const string SenderNameSelector = ".praise-dashboard>.section:nth-child(1)>.common-list-group-praise>.list-group-item:nth-child(1)>.row>.col>.user-avatar>span";
        public const string maskSelector = ".fluid-tab>.loading>.mask";
        private Button _publicCheckBox;
        private Button _firstColleagueInList;

        const string praiseDetailsHeader = ".section-header-praise>.section-header-wrapper";

        public PraisePage(Browser browser) : base(browser)
        {
            _browser = browser;
            _searchForColleague = new TextBox(browser, By.Id("search"));
            _colleague = new Button(browser, By.CssSelector(".common-list-group-organization>.list-group-item"));
            _praiseText = new TextBox(browser, By.Id("praise"));
            _valueCard = new Button(browser, By.ClassName("praise-card-item"));
            _submit = new Button(browser, By.ClassName("btn-submit-checkin"));
            _viewLastSentPraise = new Button(browser, By.CssSelector(".praise-dashboard>.section:nth-child(2)>.common-list-group-praise>.list-group-item:nth-child(1)>.row>.col:nth-child(3)>span"));
            _cancel = new Button(browser, By.ClassName("btn-cancel-checkin"));
            _publicCheckBox = new Button(browser, By.ClassName("checkbox-label"));
            _firstColleagueInList = new Button(browser, By.CssSelector(".list-group>.list-group-item:nth-child(1)>.user-avatar-organization-list"));
        }

        public string GetLastPraiseWasSentToName()
        {
            return _browser.FindElement(By.CssSelector(".section-header-praise .section-header-wrapper>span")).Text;             
        }

        public string LastPraiseWasSentTime
        {
            get
            {
                var time = _browser.FindElement(By.CssSelector(".praise-dashboard>.section:nth-child(2)>.common-list-group-praise>.list-group-item:nth-child(1)>.row>.col:nth-child(2)>span")).Text;
                return time;
            }
        }

        public string LastPraiseWasReceivedFromName
        {
            get
            {
                var senderName = _browser.FindElement(By.CssSelector(SenderNameSelector)).Text;
                return senderName;
            }
        }

        public string LastPraiseWasReceivedTime
        {
            get
            {
                var time = _browser.FindElement(By.CssSelector(".praise-dashboard>.section:nth-child(1)>.common-list-group-praise>.list-group-item:nth-child(1)>.row>.col:nth-child(2)>span")).Text;
                return time;
            }
        }

        public void CheckLastReceivedPraise()
        {
            _browser.WaitForElementVisible(By.CssSelector(SenderNameSelector));
        }

        public void GoTo()
        {
            _browser.Goto("praise/dashboard");
            _browser.WaitForPageToBeFullyLoaded();
        }

        public void SearchForAColleague(string name)
        {
            //Randomly select colleague and save the name of receiver as private field, to later use it in Receive praise test. 
            //to get login - use static user and hardcode login

            _searchForColleague.TypeText(name);
            _browser.WaitForTextToBePresentInElementLocated(By.CssSelector(".common-list-group-organization>.list-group-item"), name);
            _colleague.Click();
        }

        public void SelectColleague()
        {
            _firstColleagueInList.Click();
        }

        public void SendPraise()
        {
            //_browser.WaitForElementVisible(By.Id("praise"));
            _praiseText.TypeText("Thanks for knocking our last project out of the park and bringing new ideas all the time. Praise " + GoalsPage.GenerateLine());
            _valueCard.Click();
            _submit.Click();
            _browser.WaitForElementVisible(By.CssSelector(".praise-view"));
        }

        public void AllDoneHere()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _submit.Click();
            _browser.WaitForPageToBeFullyLoaded();

        }

        public string GetNameOfReceiver()
        {
            _browser.WaitForElementVisible(By.ClassName("user-avatar-organization-list"));
            var praiseWasSentTo = _browser.FindElements(By.ClassName("user-avatar-organization-list"))[0].Text;
            return praiseWasSentTo.Substring(0, praiseWasSentTo.IndexOf(" "));
        }

        public void SendPrivatePraise()
        {
            _praiseText.TypeText("Private praise. Thanks for knocking our last project out of the park and bringing new ideas all the time. Praise " + GoalsPage.GenerateLine());
            _valueCard.Click();
            _publicCheckBox.Click();
            _submit.Click();
            _browser.WaitForElementVisible(By.CssSelector(".praise-view"));
        }        
        
    }
}
