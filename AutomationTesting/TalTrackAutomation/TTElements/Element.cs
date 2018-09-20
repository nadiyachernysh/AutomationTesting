using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace TalTrackAutomation
{
    public class Element
    {
        protected Browser browser;
        protected By bySelect;
 
         public Element(Browser browser, By by)
         {
             this.browser = browser;
             this.bySelect = by;
         }
 
         public IWebElement GetWebElement()
         {
            //return this.browser.FindElement(this.bySelect);
            try
            {
                return this.browser.FindElement(this.bySelect);
            }
            catch (NoSuchElementException e)
            {
                Logger.Log.Error(e);
                throw e;
            }

        }

        public List<IWebElement> GetWebElements()
        {
            try
            {
                return this.browser.FindElements(this.bySelect);
            }
            catch (NoSuchElementException e)
            {
                Logger.Log.Error(e);
                throw e;
            }
            
        }

        public void Click()
         {
             this.GetWebElement().Click();
         }
 
         protected IWebElement GetChild(By by)
         {
             return this.GetWebElement().FindElement(by);
         }
 
         protected List<IWebElement> GetChildren(By by)
         {
             var elements = this.GetWebElement().FindElements(by);
 
             return elements.Count > 0 ? elements.ToList() : new List<IWebElement>();
         }
    }
}
