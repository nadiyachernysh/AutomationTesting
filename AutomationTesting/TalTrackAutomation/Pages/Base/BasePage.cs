using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TalTrackAutomation.Pages.Base
{
    public abstract class BasePage
    {
        private Browser browser;

        public BasePage(Browser browser)
        {
            this.browser = browser;
        }

        public Browser Browser { get => browser; }


        //public Browser getBrowser()
        //{
        //    return browser;
        //}

        //public void setBrowser(Browser browser)
        //{
        //    this.browser = browser;
        //}
    }
}
