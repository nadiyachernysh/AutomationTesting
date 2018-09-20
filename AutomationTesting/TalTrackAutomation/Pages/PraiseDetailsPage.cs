using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation.Pages.Base;

namespace TalTrackAutomation
{
    public class PraiseDetailsPage : BasePage
    {
        private Browser _browser;
        private Button _allDoneHere;
        private Button _backToList;

        public PraiseDetailsPage(Browser browser) : base(browser)
        {
            _browser = browser;
            _allDoneHere = new Button(browser, By.ClassName("btn-submit-checkin"));
            _backToList = new Button(browser, By.ClassName("btn-cancel-checkin"));
        }

        public string Title
        {
            get
            {
                var praisePageHeader = _browser.FindElement(By.CssSelector(".section-header-praise>.section-header-wrapper>span"));
                _browser.WaitForTextToBePresentInElement(praisePageHeader, "Praise sent to");
                var title = _browser.FindElement(By.CssSelector(".section-header-praise>.section-header-wrapper>span")).Text;
                return title;
            }
        }

        public void GoBackToList()
        {
            _browser.Pause(1);
            _backToList.Click();
            var praiseActivityHeader = _browser.FindElement(By.CssSelector(".section-header-praise>.section-header-wrapper"));
            _browser.WaitForTextToBePresentInElement(praiseActivityHeader, "Praise Activity");
            //_browser.WaitForCustom(ExpectedConditions.ElementIsVisible(By.CssSelector(".praise-dashboard>.section:nth-child(2)>.common-list-group-praise>.list-group-item:nth-child(1)>.row>.col:nth-child(2)>span")));
            //_browser.WaitForElementVisible(By.CssSelector(".praise-dashboard>.section:nth-child(2)>.common-list-group-praise>.list-group-item:nth-child(1)>.row>.col:nth-child(2)>span"));
        }

        public void AllDoneHere()
        {
            _allDoneHere.Click();
        }

        
    }
}
