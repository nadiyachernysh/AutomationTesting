using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTrackAutomation
{
    public class GoalCreator
    {
        public static string PreviousTitle { get; set; }
        public static string PreviousBody { get; set; }

        public GoalCreator(Browser browser)
        {
            GoalsPage goalsPage = new GoalsPage(browser);

        }

        //public static void CreateGoal()
        //{
        //    GoalsPage.AddGoal();// як тепер використовувати ці елементи в воркфловах, якщо немає object reference

        //    PreviousTitle = CreateTitle();
        //    PreviousBody = CreateBody();

        //    CreateGoal(PreviousTitle).WithDescription(PreviousBody).Create();
        //    Driver.Wait(TimeSpan.FromSeconds(1));
        //}

        private static string CreateBody()
        {
            return GenerateLine() + ", description";
        }

        public string CreateTitle()
        {
            return GenerateLine() + ", title";
        }

        private static string GenerateLine()
        {
            var time = $"This line was generated on : {DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.fff tt")}";
            return (time);
        }

        public static CreateGoalCommand CreateGoal(string title)
        {
            return new CreateGoalCommand(title);
        }
    }
    
    public class CreateGoalCommand
    {
        private readonly string title;
        private string description;

        public CreateGoalCommand(string title)
        {
            this.title = title;
        }

        public CreateGoalCommand WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        //public void Create()
        //{
        //    Driver.Instance.FindElement(By.Id("caption")).SendKeys(title);
        //    Driver.Instance.FindElement(By.Id("description")).SendKeys(description);
        //    Driver.Instance.FindElement(By.ClassName("btn-submit")).Click();
        //}
    }
}
