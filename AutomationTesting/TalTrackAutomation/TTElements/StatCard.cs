using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TalTrackAutomation
{
    public class StatCard : Element
    {
        private int ownGoalRatingStat;
        public StatCard(Browser browser, By by) : base(browser, by)
        {
            
        }

        public int getStatCount()
        {
            
            return int.Parse(GetWebElements()[1].Text);            
        }

        
    }
}
