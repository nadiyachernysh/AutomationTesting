using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation.Pages.Base;

namespace TalTrackAutomation
{
    public class ActivityFeedPage : BasePage
    {
        private Browser _browser;
        private Button checkNewUpdates;
        private ActivityFeedCard activityFeedCard;
        private Button _expandActivityFeed;
        private Button _closeActivityFeed;
        public ActivityFeedCard ActivityFeedCard { get { return activityFeedCard; } }

        public ActivityFeedPage(Browser browser) : base(browser)
        {
            _browser = browser;
            this.checkNewUpdates = new Button(browser, By.ClassName("btn-updates"));
            _expandActivityFeed = new Button(browser, By.ClassName("activity-expand-btn"));
            this.activityFeedCard = new ActivityFeedCard(browser, By.CssSelector(".activity-card"));
            _closeActivityFeed = new Button(browser, By.ClassName("close"));
        }

        public void CloseActivityFeed()
        {
            _closeActivityFeed.Click();
        }

        public void ExpandActivityFeed()
        {
            try
            {
                _expandActivityFeed.Click();
            }
            catch (NoSuchElementException e)
            {
                Logger.Log.Info("Activity feed was expanded by that time.", e);
            }
            
        }
        public void CheckNewUpdates()
        {
            try
                {
                    this.checkNewUpdates.Click();
                    _browser.WaitForElementVisible(By.CssSelector(".activity-card"));
                }
                catch (NoSuchElementException e)
                {
                    Logger.Log.Error(e);
                    throw;
                }            
            
        }

        public void CheckNewUpdates(string cardType)
        {
            try
            {
                this.checkNewUpdates.Click();
                //_browser.WaitForElementVisible(By.CssSelector(".activity-card-audit>." + cardType));
                //_browser.WaitForNewActivityCardWithTypeReactivate();
            }
            catch (NoSuchElementException e)
            {
                Logger.Log.Error(e);
                throw;
            }
        }
        
        public string GetFirstCardTitle()
        {
            return activityFeedCard.GoalTitle;

        }

        public string GetFirstCardAction()
        {
            return activityFeedCard.Action;
        }

        public string GetFirstCardAttribute()
        {
            return activityFeedCard.Attribute;
        }
        
    }
}
