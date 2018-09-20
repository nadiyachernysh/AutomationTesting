using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TalTrackAutomation;

namespace TalTrackAutomation
{
    public class TextBox : Element
    {
        public TextBox(Browser browser, By by) : base(browser, by)
        {

        }

        public void TypeText (string text)
        {
            try
            {
                browser.WaitForElementVisible(bySelect);
                GetWebElement().SendKeys(text);
            }
            catch (ElementNotVisibleException e)
            {
                Logger.Log.Error(e.InnerException);
                throw;
            }
            
        }
    }
}
