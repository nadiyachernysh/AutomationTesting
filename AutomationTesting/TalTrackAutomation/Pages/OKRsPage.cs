using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TalTrackAutomation.Pages.Base;
using TalTrackAutomation;

namespace TalTrackAutomation
{
    public class OKRsPage : BasePage
    {
        private Browser _browser;
        private Button _addOKR;
        private TextBox _newOKRTitle;
        private TextBox _newOKRDescription;
        private Button _submitButton;
        private TextBox _okrDescription;
        private Button _editOKR;
        private Button _addKeyResult;

        public OKRsPage(Browser browser) : base(browser)
        {
            _browser = browser;
            _addOKR = new Button(browser, By.ClassName("button-icon-add-goal"));
            _newOKRTitle = new TextBox(browser, By.Id("caption"));
            _newOKRDescription = new TextBox(browser, By.Id("description"));
            _submitButton = new Button(browser, By.CssSelector(".btn-submit"));
            _okrDescription = new TextBox(browser, By.Id("name"));
            _editOKR = new Button(browser, By.CssSelector(".button-icon-edit-goal"));
            _addKeyResult = new Button(browser, By.ClassName("btn-add-key-result"));
        }

        public string Title
        {
            get
            {
                return _browser.FindElement(By.ClassName("goal-title")).Text;
            }
        }

        public void CreateOKR()
        {
            _addOKR.Click();
            _newOKRTitle.TypeText("Product Development");
            _newOKRDescription.TypeText($"Description {GoalsPage.GenerateLine()} Co-ordinate with the strategy team to create a set of recommended (measurable) implementation tasks – scope / plan as a phase 2 project with additional budget.");
            _okrDescription.TypeText("Successfully launch version 3 of our main product");
            _submitButton.Click();
        }

        public void AddNewKeyResult()
        {
            _browser.WaitForElementNotVisible(By.CssSelector(".fluid-tab>.loading>.mask"));
            _editOKR.Click();
            _addKeyResult.Click();
            _okrDescription.TypeText("Sales team to conduct 50 phone interviews with key accounts");
            _submitButton.Click();
        }

    }
}
