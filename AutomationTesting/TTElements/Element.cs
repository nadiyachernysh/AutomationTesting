using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TTElements
{
    public class Element
    {
        private IWebDriver driver;
        private By bySelect;
 
         public Element(IWebDriver driver, By by)
         {
             this.driver = driver;
             this.bySelect = by;
         }
 
         public IWebElement getWebElement()
         {
             return this.driver.FindElement(this.bySelect);
         }
 
         public void Click()
         {
             this.getWebElement().Click();
         }
 
         protected IWebElement getChild(By by)
         {
             return this.getWebElement().FindElement(by);
         }
 
         protected List<IWebElement> getChildren(By by)
         {
             var elements = this.getWebElement().FindElements(by);
 
             return elements.Count > 0 ? elements.ToList() : new List<IWebElement>();
         }
    }
}
