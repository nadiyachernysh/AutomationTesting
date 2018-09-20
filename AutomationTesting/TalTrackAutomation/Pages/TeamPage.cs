using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation.Pages.Base;

namespace TalTrackAutomation
{
    public class TeamPage : BasePage
    {
        private Browser _browser;
        private Button _teamMemberBox;
        private Button _360FeedbackSection;
        private Button _appraisalSection;
        private Button _request360Feedback;
        private TextBox _externalEvaluator;
        public const string maskSelector = ".loading>.mask";
        private Button _submit360Request;
        private Button _close360Modal;
        private TextBox _searchForColleague;

        public TeamPage(Browser browser) : base(browser)
        {
            _browser = browser;
            _teamMemberBox = new Button(browser, By.CssSelector(".member-box>.list-group-item"));
            _360FeedbackSection = new Button(browser, By.ClassName("feedbacks"));
            _appraisalSection = new Button(browser, By.ClassName("appraisal"));
            _request360Feedback = new Button(browser, By.ClassName("button-icon-add-goal"));
            _externalEvaluator = new TextBox(browser, By.Id("externalEmail1"));
            _submit360Request = new Button(browser, By.CssSelector(".btn-submit"));
            _close360Modal = new Button(browser, By.CssSelector(".actions>.btn-submit"));
            _searchForColleague = new TextBox(browser, By.CssSelector("div.Select-placeholder"));
            
        }

        public void GoTo()
        {
            _browser.Goto("team/list");
            _browser.WaitForTextToBePresentInElementLocated(By.CssSelector(".section-header-team-members>.section-header-wrapper>span"), "Your Team");
        }

        public void SelectTeamMember()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _teamMemberBox.Click();
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _browser.WaitForElementVisible(By.ClassName("unrated"));
        }        

        public void GoTo360FeedbackSection()
        {
            _360FeedbackSection.Click();
            //_browser.WaitForElementVisible(By.ClassName("button-icon-add-goal"));            
        }

        public void SendExternal360FeedbackRequest()
        {
            _request360Feedback.Click();
            _externalEvaluator.TypeText("nadiyachernysh@gmail.com");
            _submit360Request.Click();
            _browser.WaitForTextToBePresentInElementLocated(By.CssSelector(".question"), "Thanks!");
            _close360Modal.Click();
            _browser.WaitForElementNotVisible(By.ClassName(".question"));            
        }

        //public void SendInternal360FeedbackRequest()
        //{
        //    _request360Feedback.Click();
            
        //    _searchForColleague.Click();
        //    _browser.Pause(2);
        //    _searchForColleague.TypeText("nadiya");
            
        //    _browser.Pause(2);
        //    //_searchForColleague.TypeText(Keys.Return);            
        //    _submit360Request.Click();
        //    _browser.WaitForTextToBePresentInElementLocated(By.CssSelector(".question"), "Thanks!");
        //    _close360Modal.Click();
        //    _browser.WaitForElementNotVisible(By.ClassName(".question"));
        //}

        public void GoToAppraisalSection()
        {
            _appraisalSection.Click();
        }

        //public void SelectFirstColleague()
        //{
        //    var colleague = _browser.FindElement(By.CssSelector(".Select-input>input")).GetAttribute("aria-activedescendant");
        //    var firstColleague = ;
            
        //}
        
    }
}
