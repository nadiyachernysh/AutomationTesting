using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation.Pages.Base;

namespace TalTrackAutomation
{
    public class GoalDetailsPage : BasePage
    {
        #region Fields
        private Browser _browser;
        private string _userRatingDetails;
        private Button _nudge;
        private Button _closeModalWindow;
        private Button _addFeedback;
        private Button _selectFeedbackItem;
        private Button _addFeedbackOnPopUp;
        private Button _editGoal;
        private Button _submitRatingButton;
        private Button _checkboxActive;
        private Button _checkboxPaused;
        private Button _checkboxComplete;
        private Button _checkboxMetricValue;
        private TextBox _textboxMetricValue;
        private Button _deleteGoal;
        public const string maskSelector = ".fluid-tab>.loading>.mask";
        private Button _confirmDeleteGoal;
        private Button _rateAbove;
        private Button _rateAt;
        private Button _rateBelow;
        private TextBox _ratingDetails;
        private Button _submitButton;

        #endregion

        #region Properties
        public GoalDetailsPage(Browser browser) : base (browser)
        {
            _browser = browser;
            _nudge = new Button(browser, By.ClassName("nudge-manager"));
            _closeModalWindow = new Button(browser, By.CssSelector(".modal-body>.loading>.header>.btn"));
            _addFeedback = new Button(browser, By.ClassName("btn-feedback-okr"));
            _selectFeedbackItem = new Button(browser, By.ClassName("selector"));
            _addFeedbackOnPopUp = new Button(browser, By.CssSelector(".modal-footer>.form-group>.btn-feedback"));
            _editGoal = new Button(browser, By.ClassName("button-icon-edit-goal"));
            _submitButton = new Button(browser, By.ClassName("btn-submit"));
            _submitRatingButton = new Button(browser, By.CssSelector(".button-submit-block>.btn"));
            _checkboxActive = new Button(browser, By.CssSelector(".checkbox-inline>div:nth-child(1)>label>span:nth-child(3)"));
            _checkboxPaused = new Button(browser, By.CssSelector(".checkbox-inline>div:nth-child(2)>label>span:nth-child(3)"));
            _checkboxComplete = new Button(browser, By.CssSelector(".checkbox-inline>div:nth-child(3)>label>span:nth-child(3)"));
            _checkboxMetricValue = new Button(browser, By.CssSelector(".checkbox.metric"));
            _textboxMetricValue = new TextBox(browser, By.CssSelector(".react-numeric-input>.form-control"));
            _deleteGoal = new Button(browser, By.ClassName("delete"));
            _confirmDeleteGoal = new Button(browser, By.CssSelector(".actions>.btn-submit"));
            _rateAbove = new Button(browser, By.CssSelector(".rate-buttons-block li.above a"));
            _rateAt = new Button(browser, By.CssSelector(".rate-buttons-block li.at a"));
            _rateBelow = new Button(browser, By.CssSelector(".rate-buttons-block li.below a"));
            _ratingDetails = new TextBox(browser, By.Id("formControlsTextarea"));
        }

        public string Title
        {
            get
            {
                return _browser.FindElement(By.ClassName("goal-title")).Text;                
            }
        }

        public string Description
        {
            get
            {
                return _browser.FindElement(By.ClassName(".text-block-common.block.description-block>p")).Text;                
            }
        }

        public string Status
        {
            get
            {
                return _browser.FindElement(By.CssSelector(".status")).Text;
            }
        }
        public  string UserRatingDetails
        {
            get
            {
                if (_userRatingDetails != null)
                    return _userRatingDetails;
                return String.Empty;
            }
        }
        #endregion

        #region Methods
        public void Rate(Rating rating, string details)
        {
            _browser.Pause(1);
            switch (rating)
            {
                case Rating.Above:
                    _rateAbove.Click();
                    break;

                case Rating.At:
                    _rateAt.Click();
                    break;

                case Rating.Below:
                    _rateBelow.Click();
                    break;
            }
            _ratingDetails.TypeText(details + GenerateLine() + ".  Co-ordinate with the strategy team to create a set of recommended (measurable) implementation tasks – scope / plan as a phase 2 project with additional budget");
            _browser.WaitForPageToBeFullyLoaded();
            _submitRatingButton.Click();
            //need to create separate test cases for goals with OKRs
            //if (_browser.FindElement(By.ClassName("question")).Displayed)
            //{
            //    _submitOnOkrModal.Click();
            //    _browser.WaitForElementNotVisible(By.ClassName("question"));
            //}

        }

        public static string GenerateLine()
        {
            var line = $" generated on : {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt")}";
            return (line);
        }

        public void CheckIfGoalCanBeNudged()
        {
           
        }

        
        public void SendNudge()
        {            
            _nudge.Click();
            _browser.WaitForTextToBePresentInElementLocated(By.CssSelector(".nudge-text>span"), "You've nudged your manager to rate the goal:");
            _closeModalWindow.Click();
        }

        public void AddFeedback()
        {
            _addFeedback.Click();
            _browser.WaitForTextToBePresentInElementLocated(By.Id("contained-modal-title-lg"), "Add Feedback to goal");
            _selectFeedbackItem.Click();
            _addFeedbackOnPopUp.Click();
            _browser.WaitForElementNotVisible(By.CssSelector(".modal-footer>.form-group>.btn-feedback"));
        }

        public void PauseGoal()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _editGoal.Click();
            _checkboxPaused.Click();
            _submitButton.Click();
        }

        public void ReactivateGoal()
        {
            _browser.WaitForElementVisible(By.ClassName("rate-circle-indicator"));
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _browser.Pause(1);            
            _editGoal.Click();
            _checkboxActive.Click();
            _submitButton.Click();            
            _browser.Pause(1);
        }

        public void CompleteGoal()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _editGoal.Click();
            _checkboxComplete.Click();
            _submitButton.Click();
        }

        public void AddMetricTarget()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _editGoal.Click();
            _checkboxMetricValue.Click();            
            _textboxMetricValue.TypeText("10");
            _submitButton.Click();
        }

        public void UpdateMetricTarget()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _textboxMetricValue.TypeText("10");
        }

        public void DeleteGoal()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));
            _browser.Pause(1);
            _editGoal.Click();
            _deleteGoal.Click();
            _browser.WaitForTextToBePresentInElementLocated(By.ClassName("question"), "Are you sure you want to delete this goal?");
            _confirmDeleteGoal.Click();
            _browser.WaitForElementNotVisible(By.CssSelector(".actions>.btn-submit"));
        }
        #endregion
    }
}
