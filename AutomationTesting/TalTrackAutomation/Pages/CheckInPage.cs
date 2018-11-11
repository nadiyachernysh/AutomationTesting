using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation.Pages.Base;
using OpenQA.Selenium;

namespace TalTrackAutomation.Pages
{
    public class CheckInPage : BasePage
    {
        private Browser _browser;
        string maskSelector = ".fluid-tab>.loading>.mask";        
        private Button _checkInTool;
        private Button _reviewGoals;
        private TextBox _commentToGoal;
        private TextBox _commentAboutPerformance;
        private TextBox _commentAboutSteps;
        private Button _reviewPerformance;
        private Button _nextSteps;
        private Button _preview;
        private Button _edit;
        private Button _submit;
        private Button _goToTalTrack;
        string checkInItemSelector = ".common-list-group-checkins .list-group-item";
                

        public CheckInPage(Browser browser) : base(browser)
        {
            _browser = browser;
            _checkInTool = new Button(browser, By.ClassName("btn-view-checkin"));
            _reviewGoals = new Button(browser, By.ClassName("glyphicon-plus"));
            _commentToGoal = new TextBox(browser, By.Id("goalNote1257"));
            _commentAboutPerformance = new TextBox(browser, By.Id("perfNote"));
            _commentAboutSteps = new TextBox(browser, By.Id("stepsNote"));
            _reviewPerformance = new Button(browser, By.ClassName("glyphicon-plus"));
            _nextSteps = new Button(browser, By.ClassName("glyphicon-plus"));
            _preview = new Button(browser, By.ClassName("preview"));
            _submit = new Button(browser, By.ClassName("submit"));
            _edit = new Button(browser, By.ClassName("edit"));
            _goToTalTrack = new Button(browser, By.ClassName("btn-submit"));
        }

        public void GoTo()
        {
            _browser.Pause(2);
            _browser.Goto("checkin/items/");
            _browser.Pause(1);
            _browser.WaitForPageToBeFullyLoaded();
        }

        public void OpenUnsubmittedCheckIn()
        {
            _browser.WaitForElementVisible(By.CssSelector(checkInItemSelector));
            var checkIns = _browser.FindElements(By.CssSelector(checkInItemSelector));
            foreach (var checkIn in checkIns)
            {
                checkIn.Click();
                _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
                
                if (_browser.IsElementPresent(By.ClassName("btn-view-checkin")))
                {
                    _checkInTool.Click();                    
                    break;
                }                    
            }            
        }

        public void OpenReviewGoals()
        {
            _browser.Pause(1);
            _reviewGoals.Click();
            _browser.WaitForElementVisible(By.ClassName("auto-size-wrapper"));
        }

        public void AddCommentToGoal()
        {      
            _commentToGoal.TypeText("This this comment to a goal. ");            
        }

        public void AddPerformanceComment()
        {
            _reviewPerformance.Click();
            _commentAboutPerformance.TypeText("This is comment about performance. ");
        }

        public void AddStepsComment()
        {
            _nextSteps.Click();
            _commentAboutSteps.TypeText("Moving towards. ");
        }

        public void PreviewCheckIn()
        {
            _preview.Click();
        }

        public string GetCommentAboutSteps()
        {
            return _browser.FindElement(By.Id("stepsNote")).Text;
        }

        public void Edit()
        {
            _edit.Click();
            _commentAboutSteps.TypeText("Updated comment. ");
        }

        public void Submit()
        {
            _submit.Click();
        }

        public string GetConfirmationText()
        {
            return _browser.FindElement(By.CssSelector(".confirmation>p:nth-child(2)")).Text;
        }
        
        public void GoBack()
        {
            _browser.WaitForElementNotVisible(By.ClassName("mask"));
            _goToTalTrack.Click();
            _browser.WaitForElementVisible(By.CssSelector(checkInItemSelector));
        }

        public string GetCheckInHeader()
        {
            return _browser.FindElement(By.ClassName("section-header-check-in-submitted")).Text;
        }

        public void RateProgressOnObjectives()
        {
            var objectivesInCheckIn = _browser.FindElements(By.CssSelector(".rate-buttons-block li.above a"));
            foreach (var objective in objectivesInCheckIn)
            {
                objective.Click();
            }
        }
    }    
}
