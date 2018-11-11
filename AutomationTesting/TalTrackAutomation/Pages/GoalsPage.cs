using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using TalTrackAutomation.Pages.Base;

namespace TalTrackAutomation
{
    public class GoalsPage : BasePage
    {
        private Browser _browser;
        private Button _rateAbove;
        private Button _rateAt;
        private Button _rateBelow;
        private TextBox _ratingDetails;
        private Button _submitButton;
        private Button _addGoal;
        private Button _editGoal;
        private TextBox _newGoalTitle;
        private TextBox _newGoalDescription;
        private Button _archivedGoalsTab;
        private Button _submitOnOkrModal;
        private Button _goalProgressCircle;

        public const string maskSelector = ".fluid-tab>.loading>.mask";

        public static string ActiveGoalTitle { get; set; }
        public static string ActiveGoalDescription { get; set; }

        public GoalsPage(Browser browser) : base(browser)
        {
            _browser = browser;
            _rateAbove = new Button(browser, By.CssSelector(".rate-buttons-block li.above a"));
            _rateAt = new Button(browser, By.CssSelector(".rate-buttons-block li.at a"));
            _rateBelow = new Button(browser, By.CssSelector(".rate-buttons-block li.below a"));
            _ratingDetails = new TextBox(browser, By.Id("formControlsTextarea"));
            _submitButton = new Button(browser, By.CssSelector(".button-submit-block>.btn"));
            _addGoal = new Button(browser, By.ClassName("button-icon-add-goal"));
            _editGoal = new Button(browser, By.ClassName("button-icon-edit-goal"));
            _newGoalTitle = new TextBox(browser, By.Id("caption"));
            _newGoalDescription = new TextBox(browser, By.Id("description"));
            _archivedGoalsTab = new Button(browser, By.CssSelector(".nav-tabs>li:nth-child(2)"));
            _submitOnOkrModal = new Button(browser, By.CssSelector(".delete-confirm.modal-dialog .actions .btn:last-child"));
            _goalProgressCircle = new Button(browser, By.ClassName("goal-progress"));

        }

        public void GoTo()
        {
            _browser.Goto("goals");
            //_browser.WaitForElementVisible(By.ClassName("unrated"));
            _browser.WaitForCustom(ExpectedConditions.ElementIsVisible(By.ClassName("actions")));

        }

        public void SelectUnratedGoal()
        {
            
            var ratingsOfUser = _browser.FindElements(By.CssSelector(".list-group-item>span:nth-child(2)>div:nth-child(1)"));
            foreach (var rating in ratingsOfUser)
            {
                var ratingIndicator = rating.GetAttribute("class");
                if (ratingIndicator.Equals("rate-circle-indicator unrated small", StringComparison.Ordinal))
                {
                    rating.Click();
                    _browser.WaitForElementVisible(By.CssSelector(".status"));
                    string neededStatus = "ACTIVE";
                    var status = _browser.FindElement(By.CssSelector(".status")).Text;                                    
                    if (status.Equals(neededStatus, StringComparison.Ordinal))                        
                        break;
                }
            }
            _browser.WaitForElementClickable(By.CssSelector(".rate-buttons-block"));
        }

        public void SelectUnratedGoalWithoutMetricTarget()
        {
            var ratingsOfUser = _browser.FindElements(By.CssSelector(".list-group-item>span:nth-child(2)>div:nth-child(1)"));
            foreach (var rating in ratingsOfUser)
            {
                var ratingIndicator = rating.GetAttribute("class");
                if (ratingIndicator.Equals("rate-circle-indicator unrated small", StringComparison.Ordinal))
                {
                    rating.Click();
                    _browser.WaitForElementVisible(By.CssSelector(".status"));
                    string neededStatus = "ACTIVE";
                    var status = _browser.FindElement(By.CssSelector(".status")).Text;                    
                    _browser.WaitForElementNotVisible(By.CssSelector(maskSelector));                    
                    if (status.Equals(neededStatus, StringComparison.Ordinal) && _browser.IsElementPresent(By.ClassName("metric-slider-widget")))
                        break;
                }
            }
            _browser.WaitForElementClickable(By.CssSelector(".rate-buttons-block"));
        }

        public void SelectUnratedGoalWithMetricTarget()
        {

            var ratingsOfUser = _browser.FindElements(By.CssSelector(".list-group-item>span:nth-child(2)>div:nth-child(1)"));
            foreach (var rating in ratingsOfUser)
            {
                var ratingIndicator = rating.GetAttribute("class");
                if (ratingIndicator.Equals("rate-circle-indicator unrated small", StringComparison.Ordinal))
                {
                    rating.Click();
                    _browser.WaitForElementVisible(By.ClassName("metric-slider-widget"));
                    
                    if (_browser.IsElementPresent(By.ClassName("metric-slider-widget")))                        
                        break;                  
                }
            }
            _browser.WaitForElementClickable(By.CssSelector(".rate-buttons-block"));
        }

        public void SelectGoalRatedOnlyByUser()
        {
            var ratingsOfUser = _browser.FindElements(By.CssSelector(".list-group-item>span:nth-child(2)>div:nth-child(1)"));
            var ratingsOfManager = _browser.FindElements(By.CssSelector(".list-group-item>span:nth-child(2)>div:nth-child(2)"));
            int i = 0;
            foreach (var rating in ratingsOfUser)
            {
                var ratingIndicator = rating.GetAttribute("class");
                
                if(!ratingIndicator.Equals("rate-circle-indicator unrated small", StringComparison.Ordinal) && ratingsOfManager[i].GetAttribute("class").Equals("rate-circle-indicator unrated small", StringComparison.Ordinal))
                {
                    rating.Click();                    
                    break;
                }
                i++;
            } 
        }


        public void SelectPausedGoal()
        {
            _browser.Pause(1);
            var ratingsOfUser = _browser.FindElements(By.CssSelector(".list-group-item>span:nth-child(2)>div:nth-child(1)"));
            foreach (var rating in ratingsOfUser)
            {
                rating.Click();
                _browser.WaitForElementVisible(By.CssSelector(".status"));
                string neededStatus = "PAUSED";
                var status = _browser.FindElement(By.CssSelector(".status")).Text;
                bool result = status.Equals(neededStatus, StringComparison.Ordinal);
                if (result == true)                
                    break;                
            }            
        }
                
        public void CreateGoal()
        {
            _addGoal.Click();
            _newGoalTitle.TypeText("Product Development");
            _newGoalDescription.TypeText("Description" + GenerateLine() + ".  Co-ordinate with the strategy team to create a set of recommended (measurable) implementation tasks – scope / plan as a phase 2 project with additional budget.");
            _submitButton.Click();
        }

        public void EditGoal()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(".fluid-tab>.loading>.mask"));
            _editGoal.Click();
            _newGoalDescription.TypeText("Update" + GenerateLine());
            _submitButton.Click();
        }

        public static string GenerateLine()
        {
            var line = $" generated on : {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt")}";
            return (line);
        }

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
            _submitButton.Click();
            //need to create separate test cases for goals with OKRs
            //if (_browser.FindElement(By.ClassName("question")).Displayed)
            //{
            //    _submitOnOkrModal.Click();
            //    _browser.WaitForElementNotVisible(By.ClassName("question"));
            //}

        }

        public void SwitchToArchivedGoalsTab()
        {
            _archivedGoalsTab.Click();
        }

        public static RateGoalCommand RateGoal(Rating rating)
        {
            return new RateGoalCommand(rating);
        }

        public class RateGoalCommand
        {
            private string details;
            private Rating rating;

            public RateGoalCommand(Rating rating)
            {
                this.rating = rating;
            }
            public RateGoalCommand AddDetails(string details)
            {
                this.details = details;
                return this;
            }

            public void Rate()
            {
            }
        }

    }

    public enum Rating
    {
        Above,
        At,
        Below
    }
}
