using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TalTrackAutomation;

namespace TalTrackAutomation
{
    public class Button : Element
    {
        public Button(Browser browser, By by) : base(browser, by)
        {

        }

        new public void Click()
        {
            try
            {
                //
                browser.WaitForElementClickable(bySelect);
                GetWebElement().Click();
            }
            catch (NoSuchElementException e)
            {
                Logger.Log.Error(e.Message);
                throw;
            }
            catch (InvalidOperationException e)
            {
                Logger.Log.Error(e.Message);
                throw;
            }            
        }        
    }
}
