using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation.Pages.Base;

namespace TalTrackAutomation.Pages
{
    public class FeedbackPage : BasePage
    {
        private Browser _browser;
        private Button _addToGoal;
        private Button _selectGoalItem;
        private Button _addGoalOnPopUp;
        private Button _detachFeedback;
        const string maskSelector = ".fluid-tab>.loading>.mask";
        private Button _sendPraiseBack;

        public FeedbackPage(Browser browser) : base(browser)
        {
            _browser = browser;
            _addToGoal = new Button(browser, By.CssSelector(".btn-feedback"));
            _selectGoalItem = new Button(browser, By.ClassName("selector"));
            _addGoalOnPopUp = new Button(browser, By.CssSelector(".modal-dialog.modal-feedback .btn-feedback"));
            _detachFeedback = new Button(browser, By.ClassName("list-remove-sign"));
            _sendPraiseBack = new Button(browser, By.ClassName("btn-cancel"));
        }

        public string LabelAttachedToGoal => _browser.FindElement(By.CssSelector(".message-card .footer>p")).Text;

        public void GoTo()
        {
            _browser.Goto("feedback");
            _browser.WaitForPageToBeFullyLoaded();
            //_browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            //
        }

        public void SelectPraise()
        {
            var feedbackTitles = _browser.FindElements(By.CssSelector(".common-list-group.list-group.common-list-group-feedback .list-group-item"));

            foreach(var title in feedbackTitles)
            {
                if(title.Text.Substring(0,title.Text.IndexOf(" ")).Equals("Praise"))
                {
                    title.Click();
                    break;
                }
            }
        }

        public string AddFeedbackToGoal()
        {
            //_browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _browser.Pause(1);
            _addToGoal.Click();
            _browser.WaitForTextToBePresentInElementLocated(By.Id("contained-modal-title-lg"), "Add Feedback to Goal");
            _browser.Pause(1);
            var titleOfSelectedGoal = _browser.FindElements(By.CssSelector(".common-list-group.list-group.common-list-group-goals-popup .list-group-item strong"))[0].Text;
            var shortTitle = titleOfSelectedGoal.Substring(0, titleOfSelectedGoal.IndexOf(" "));
            _selectGoalItem.Click();
            _addGoalOnPopUp.Click();
            _browser.WaitForElementNotVisible(By.CssSelector(".modal-dialog.modal-feedback .btn-feedback"));
            return shortTitle;
        }

        public string GetTitleOfAttachedGoal()
        {
            var titleOfAttachedGoal = _browser.FindElement(By.ClassName("feedback-goal-item")).Text;
            var shortTitleOfAttachedGoal = titleOfAttachedGoal.Substring(0, titleOfAttachedGoal.IndexOf(" "));
            return shortTitleOfAttachedGoal;
        }

        public void DetachFeedback()
        {
            _detachFeedback.Click();
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
        }

        public bool CheckThatFeedbackHasNoAttachedGoal()
        {
            return _browser.IsElementPresent(By.CssSelector(".message-card .footer"));
        }

        public void SendPraiseBack()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _browser.Pause(1);
            _sendPraiseBack.Click();
            _browser.Pause(1);
        }
    }
}
