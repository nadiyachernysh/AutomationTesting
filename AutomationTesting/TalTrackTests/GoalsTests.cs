using System;
using TalTrackAutomation;
using NUnit.Framework;


namespace TalTrackTests
{
    [TestFixture]
    public class GoalsTests : TestBase
    {
        [Test, Order(1)]
        public void Can_Create_Own_Goal()
        {
            GoalsPage goalsPage = new GoalsPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalsPage.CreateGoal();            
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();

            Assert.AreEqual("Created a Goal", activityFeedPage.GetFirstCardAction());            
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order(2)]
        public void Can_Edit_Own_Goal()
        {
            GoalsPage goalsPage = new GoalsPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalsPage.EditGoal();
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();
            Assert.AreEqual("Edited a Goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order(3)]
        public void Can_Rate_Own_Goal_Above()
        {
            HomePage homePage = new HomePage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);

            homePage.GoTo();
            var ownRatedGoalsBefore = homePage.GetRatedOwnGoalsCount();
            
            goalsPage.GoTo();
            goalsPage.SelectUnratedGoal();
            goalsPage.Rate(Rating.Above, "Details of rating above expectation");

            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();
            Assert.AreEqual("Rated a Goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            homePage.GoTo();
            var ownRatedGoalsAfter = homePage.GetRatedOwnGoalsCount();
            Assert.AreEqual(ownRatedGoalsBefore + 1, ownRatedGoalsAfter);

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order(4)]
        public void Can_Rate_Own_Goal_At()
        {
            HomePage homePage = new HomePage(browser);            
            GoalsPage goalsPage = new GoalsPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            homePage.GoTo();
            var ownRatedGoalsBefore = homePage.GetRatedOwnGoalsCount();
            goalsPage.GoTo();
            goalsPage.SelectUnratedGoal();
            goalsPage.Rate(Rating.At, "Details of rating at expectation");            
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();

            Assert.AreEqual("Rated a Goal", activityFeedPage.GetFirstCardAction());            
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            homePage.GoTo();
            var ownRatedGoalsAfter = homePage.GetRatedOwnGoalsCount();
            Assert.AreEqual(ownRatedGoalsBefore + 1, ownRatedGoalsAfter);

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order(5)]
        public void Can_Rate_Own_Goal_Below()
        {
            HomePage homePage = new HomePage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            homePage.GoTo();
            var ownRatedGoalsBefore = homePage.GetRatedOwnGoalsCount();

            goalsPage.GoTo();
            goalsPage.SelectUnratedGoal();
            goalsPage.Rate(Rating.Below, "Details of rating below expectation");            
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();

            Assert.AreEqual("Rated a Goal", activityFeedPage.GetFirstCardAction());            
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            homePage.GoTo();
            var ownRatedGoalsAfter = homePage.GetRatedOwnGoalsCount();
            Assert.AreEqual(ownRatedGoalsBefore + 1, ownRatedGoalsAfter);

            activityFeedPage.CloseActivityFeed();
        }

        
        [Test, Order(7)]
        public void Can_Nudge()
        {
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalsPage.SelectGoalRatedOnlyByUser();
            goalDetailsPage.SendNudge();
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();
            Assert.AreEqual("Nudged a manager to rate a Goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order(8)]
        public void Can_Attach_Feedback_To_Goal()
        {
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalDetailsPage.AddFeedback();
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();
            Assert.AreEqual("Added Feedback to a Goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order(9)]
        public void Can_Complete_Own_Goal()
        {
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalDetailsPage.CompleteGoal();
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();
            Assert.AreEqual("Completed a Goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order(10)]
        public void Can_Pause_Own_Goal()
        {
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalDetailsPage.PauseGoal();
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();
            Assert.AreEqual("Paused a Goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }              

        [Test, Order(11)]
        public void Can_Add_Metric_Target()
        {
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalsPage.SelectUnratedGoal();
            goalDetailsPage.AddMetricTarget();
        }

        [Test, Order(12)]
        public void Can_Rate_Goal_With_Metric_Target()
        {
            HomePage homePage = new HomePage(browser);            
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalsPage.SelectUnratedGoalWithMetricTarget();
            goalDetailsPage.UpdateMetricTarget();
            goalsPage.Rate(Rating.At, "Details of rating at expectation");
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();

            Assert.AreEqual("Rated a Goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());            

            activityFeedPage.CloseActivityFeed();

            //need to add an assert for % result here, after goal was rated ( 10 divided by number on the scale)
        }


        [Test, Order(13)]
        public void Can_Reactivate_Own_Goal()
        {
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalsPage.SwitchToArchivedGoalsTab();
            goalsPage.SelectPausedGoal();
            goalDetailsPage.ReactivateGoal();
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();
            Assert.AreEqual("Reactivated a Goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order (14)]
        public void Can_Delete_Own_Goal()
        {
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);

            goalsPage.GoTo();
            goalsPage.CreateGoal();
            goalDetailsPage.DeleteGoal();

            activityFeedPage.ExpandActivityFeed();            

            //Assert.AreEqual("activity-card activity-card-audit disabled-event", activityFeedPage.GetFirstCardAttribute());

            activityFeedPage.CloseActivityFeed();
        }        
        
    }
}