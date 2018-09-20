using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using log4net.Config;
using System.IO;

namespace TalTrackAutomation
{
    public class Browser
    {
        #region Fields

        private string BaseAddress = "https://stageapp.taltrack.com/";
        private IWebDriver _webDriver;
        #endregion

        #region Properties

        private IWebDriver WebDriver
        {
            get
            {
                if (_webDriver == null)
                {
                    var chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArgument("incognito");
                    _webDriver = new ChromeDriver(chromeOptions);
                    _webDriver.Manage().Window.Maximize();

                    //_webDriver = new FirefoxDriver();

                }
                return _webDriver;
            }
        }

        public void WaitFor(Func<IWebDriver, bool> waitStrategy, int timeout = 5)
        {
            try
            {
                GetWebDriverWait(timeout).Until(waitStrategy);
            }
            catch (Exception )
            {

                throw;
            }
            
        }

        //private WebDriverWait Wait
        //{
        //    get
        //    {
        //        if (this._wait == null)
        //        {
        //            this._wait = new WebDriverWait(this.WebDriver, TimeSpan.FromSeconds(5));
        //        }
        //        return _wait;
        //    }
        //}

        #endregion

        #region Methods

        public TResult WaitForCustom<TResult>(Func<IWebDriver, TResult> expectedCondition)
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            return wait.Until(expectedCondition);
        }               

        public bool IsElementPresent(By selector, int timeout = 2)
        {
            try
            {
                WebDriver.FindElement(selector);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void SwitchToNewTab()
        {
            string newTabHandle = _webDriver.WindowHandles.Last();
            _webDriver.SwitchTo().Window(newTabHandle);
            
        }

        public void Initialize()
        {
            Goto("login");
        }

        public void SwitchToModalWindow()
        {
            _webDriver.SwitchTo().ActiveElement();
            //тут можна ловити експшн, логувати і кидати

            //string current = _webDriver.CurrentWindowHandle;
            //PopupWindowFinder finder = new PopupWindowFinder(_webDriver);
            //string newHandle = finder.Click(_webDriver.FindElement(By.ClassName("nudge-manager")));
            //_webDriver.SwitchTo().Window(newHandle);

            //switchToModalDialog(_webDriver, parent = _webDriver.CurrentWindowHandle);
        }

        public List<IWebElement> FindElements(By bySelect)
        {
            return this.WebDriver.FindElements(bySelect).ToList();
        }

        public IWebElement FindElement(By bySelect)
        {
            return this.WebDriver.FindElement(bySelect);
        }

        public void Goto(string url)
        {
            WebDriver.Url = BaseAddress + url;
        }

        public string Title
        {
            get { return WebDriver.Title; }
        }

        public void Navigate(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public void Close()
        {
            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Quit();
        }

        public string TakeScreenshot(string directory)//, string name
        {
            var screenshot = ((ITakesScreenshot)WebDriver).GetScreenshot();
            var path = directory + "\\Screenshots" + "\\Screenshot_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".jpg";            
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg);
            return path;            
        }

        public void Pause(int timeout)
        {
            Thread.Sleep(timeout*1000);
        }        

        public void WaitForElementVisible(By selector, int timeout = 5)
        {
            try
            {
                GetWebDriverWait(timeout).Until(ExpectedConditions.ElementIsVisible(selector));
            }
            catch (ElementNotVisibleException e)
            {
                Logger.Log.Error(e);
                throw e;
            }
            
        }

        public void WaitForTextToBePresentInElementValue(By selector, string text, int timeout = 5)
        {
            try
            {
                GetWebDriverWait(timeout).Until(ExpectedConditions.TextToBePresentInElementValue(selector, text));
            }
            catch (NoSuchElementException e)
            {
                Logger.Log.Error(e);
                throw;
            }
        }

        //public void WaitFor (Func<IWebDriver, IWebElement> condition, By selector, int timeout = 5)
        //{
        //    GetWebDriverWait(timeout).Until(condition(selector));
        //}

        public void WaitForElementClickable(By selector, int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(ExpectedConditions.ElementToBeClickable(selector));
        }

        public void WaitForElementClickableByElement (IWebElement element, int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForTextToBePresentInElement (IWebElement element, string text, int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public void WaitForTextToBePresentInElementLocated(By selector, string text, int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(ExpectedConditions.TextToBePresentInElementLocated(selector, text));
        }

        public void WaitForElementNonZero(By selector, int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(CustomConditions.ElementIsNonZero(selector));
        }

        public void WaitForNewActivityCard(int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(CustomConditions.ActivityCardIsNew());
        }

        public void WaitForNewActivityCardWithTypeReactivate(int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(CustomConditions.ActivityCardWithReactivateActionIsNew());
        }

        public void WaitForElementNotVisible(By selector, int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(ExpectedConditions.InvisibilityOfElementLocated(selector));
        }

        public void WaitForPageToBeFullyLoaded(int timeout = 5)
        {
            GetWebDriverWait(timeout).Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
            //GetWebDriverWait(timeout).Until(d => (Boolean)((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active == 0"));

        }

        public IWait<IWebDriver> GetWebDriverWait(int timeout)
        {
            return new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeout));            
        }

        #endregion
    }
}