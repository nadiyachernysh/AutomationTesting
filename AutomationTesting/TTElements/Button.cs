using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TTElements
{
    public class Button : Element
    {
        public Button(IWebDriver driver, By by) : base(driver, by)
        {

        }

        new public void Click()
        {
            getWebElement().Click();
        }
    }
}
