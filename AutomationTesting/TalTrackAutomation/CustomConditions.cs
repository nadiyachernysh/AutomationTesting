using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTrackAutomation
{
    public static class CustomConditions
    {
        public static Func<IWebDriver, bool> ElementIsNonZero(By locator)
        {
            return (d =>
                {
                    var element = d.FindElement(locator);
                    var number = int.Parse(element.Text);
                    if (number != 0)                    
                        return true;
                    return false;
                }
            );
        }

        public static Func<IWebDriver, bool> ActivityCardIsNew()//"reactivate"
        {
            return (d =>
                {
                    var timestamp = d.FindElement(By.CssSelector(".user-avatar.user-avatar-header-activity-card>span")).Text;
                    if (timestamp.StartsWith("1s") || timestamp.StartsWith("2s") || timestamp.StartsWith("3s"))
                        return true;
                    return false;
                }
            );
        }

        public static Func<IWebDriver, bool> ActivityCardWithReactivateActionIsNew()
        {
            return (d =>
                {
                    var timestamp = d.FindElement(By.CssSelector(".user-avatar.user-avatar-header-activity-card>span")).Text;
                    var cardType = d.FindElement(By.CssSelector(".activity-card-audit>.reactivate")).GetAttribute("class");

                    if (timestamp.StartsWith("1s") || timestamp.StartsWith("2s") || timestamp.StartsWith("3s") && cardType.Equals("card-subject card-subject-audit reactivate", StringComparison.Ordinal))
                        return true;
                    return false;
                }
            );
        }

    }
}
