using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTrackAutomation
{
    public class ActivityFeedCard : Element
    {
        private Func<IWebDriver, bool> _waitStrategy;
        public ActivityFeedCard(Browser browser, By by) : base(browser, by) //можна створити ще один конструктор і  передавати вейт стратеджі третім параметром
        {
           
        }

        public ActivityFeedCard(Browser browser, By by, Func<IWebDriver, bool> WaitStrategy) : base(browser, by) //можна створити ще один конструктор і  передавати вейт стратеджі третім параметром
        {
            _waitStrategy = WaitStrategy;
        }
        public string Action
        {
            get
            {
                if (_waitStrategy != null)
                {
                    browser.WaitFor(_waitStrategy);
                }
                else
                {
                    browser.WaitForNewActivityCard();
                }
                return GetChild(By.CssSelector(".activity-card .card-header p")).Text;                
            }
        }

        public string GoalTitle
        {
            get
            {
                browser.WaitForNewActivityCard();
                return GetChild(By.CssSelector(".activity-card .card-subject p")).Text;
            }
                
        }

        public string Attribute
        {
            get
            {
                browser.WaitForNewActivityCard();
                return GetChild(By.ClassName("disabled-event")).GetAttribute("class");
            }
        }


        public bool IsVisible { 
            get
            {
                browser.WaitForElementVisible(bySelect);
                return GetWebElement().Displayed;
            }
        }
        
    }
}
