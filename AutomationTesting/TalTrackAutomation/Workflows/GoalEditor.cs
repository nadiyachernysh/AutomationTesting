using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTrackAutomation
{
    public class GoalEditor
    {
        public static string EditedTitle { get; set; }
        public static object EditedDescription { get; set; }

        public static void EditGoal()
        {
            //GoalsPage.SelectActiveGoal();

            //EditedTitle = GoalsPage.ActiveGoalTitle + ", edited title.";

            //EditedDescription = GoalsPage.ActiveGoalDescription + ", edited description.";

            //EditGoal(", edited title.").Description(", edited description.").Edit();
        }

        public static EditGoalCommand EditGoal(string title)
        {
            return new EditGoalCommand(title);
        }
    }

    public class EditGoalCommand
    {
        private string title;
        private string description;

        public EditGoalCommand(string title)
        {
            this.title = title;
        }

        public EditGoalCommand Description(string description)
        {
            this.description = description;
            return this;
        }

        public void Edit()
        {
            //Driver.Instance.FindElement(By.ClassName("button-icon-edit-goal")).Click();
            //Driver.Wait(TimeSpan.FromSeconds(1));
            //Driver.Instance.FindElement(By.Id("caption")).SendKeys(title);
            //Driver.Wait(TimeSpan.FromSeconds(1));
            //Driver.Instance.FindElement(By.Id("description")).SendKeys(description);
            //Driver.Wait(TimeSpan.FromSeconds(1));
            //Driver.Instance.FindElement(By.ClassName("btn-submit")).Click();
        }
    }
}
