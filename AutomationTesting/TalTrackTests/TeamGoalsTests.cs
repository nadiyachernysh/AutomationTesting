using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation;

namespace TalTrackTests
{
    [TestFixture]
    public class TeamGoalsTests : TestBase
    {
        [Test]
        public void Manager_Can_Rate_TeamMembers_Goal_Above()
        {
            HomePage homePage = new HomePage(browser);
            var teamsRatedGoalsBefore = homePage.GetRatedTeamsGoalsCount();
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);
            TeamPage teamPage = new TeamPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);

            teamPage.GoTo();
            teamPage.SelectTeamMember();
            goalsPage.SelectUnratedGoal();
            goalsPage.Rate(Rating.Above, "Manager's rating above expectation");
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();

            Assert.AreEqual("You rated their goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            homePage.GoTo();
            var teamsRatedGoalsAfter = homePage.GetRatedTeamsGoalsCount();
            Assert.AreEqual(teamsRatedGoalsBefore + 1, teamsRatedGoalsAfter);

            activityFeedPage.CloseActivityFeed();
        }

        [Test]
        public void Manager_Can_Rate_TeamMembers_Goal_At()
        {
            HomePage homePage = new HomePage(browser);
            var teamsRatedGoalsBefore = homePage.GetRatedTeamsGoalsCount();
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);
            TeamPage teamPage = new TeamPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);

            teamPage.GoTo();
            teamPage.SelectTeamMember();
            goalsPage.SelectUnratedGoal();
            goalsPage.Rate(Rating.At, "Manager's rating at expectation");
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();

            Assert.AreEqual("You rated their goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            homePage.GoTo();
            var teamsRatedGoalsAfter = homePage.GetRatedTeamsGoalsCount();
            Assert.AreEqual(teamsRatedGoalsBefore + 1, teamsRatedGoalsAfter);

            activityFeedPage.CloseActivityFeed();
        }

        [Test]
        public void Manager_Can_Rate_TeamMembers_Goal_Below()
        {
            HomePage homePage = new HomePage(browser);
            
            GoalsPage goalsPage = new GoalsPage(browser);
            GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);
            TeamPage teamPage = new TeamPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);

            homePage.GoTo();
            var teamsRatedGoalsBefore = homePage.GetRatedTeamsGoalsCount();

            teamPage.GoTo();
            teamPage.SelectTeamMember();
            goalsPage.SelectUnratedGoal();
            goalsPage.Rate(Rating.Below, "Manager's rating below expectation");
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();

            Assert.AreEqual("You rated their goal", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

            homePage.GoTo();
            var teamsRatedGoalsAfter = homePage.GetRatedTeamsGoalsCount();
            Assert.AreEqual(teamsRatedGoalsBefore + 1, teamsRatedGoalsAfter);

            activityFeedPage.CloseActivityFeed();
        }

        //[Test]
        //public void Manager_Can_Rate_TeamMembers_Goals_Multiple()
        //{
        //    HomePage homePage = new HomePage(browser);
        //    var teamsRatedGoalsBefore = homePage.GetRatedTeamsGoalsCount();
        //    GoalsPage goalsPage = new GoalsPage(browser);
        //    GoalDetailsPage goalDetailsPage = new GoalDetailsPage(browser);
        //    TeamPage teamPage = new TeamPage(browser);
        //    ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);

        //    teamPage.GoTo();
        //    teamPage.SelectTeamMember();
        //    goalsPage.SelectUnratedGoal();
        //    goalsPage.Rate(Rating.Above, "Manager's rating above expectation");
        //    activityFeedPage.ExpandActivityFeed();
        //    activityFeedPage.CheckNewUpdates();
        //    Assert.AreEqual("Rated a Goal", activityFeedPage.GetFirstCardAction());
        //    Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

        //    goalsPage.SelectUnratedGoal();
        //    goalsPage.Rate(Rating.At, "Manager's rating at expectation");
        //    activityFeedPage.CheckNewUpdates();
        //    Assert.AreEqual("Rated a Goal", activityFeedPage.GetFirstCardAction());
        //    Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

        //    goalsPage.SelectUnratedGoal();
        //    goalsPage.Rate(Rating.Below, "Manager's rating below expectation");
        //    activityFeedPage.CheckNewUpdates();
        //    Assert.AreEqual("Rated a Goal", activityFeedPage.GetFirstCardAction());
        //    Assert.AreEqual(goalDetailsPage.Title, activityFeedPage.GetFirstCardTitle());

        //    homePage.GoTo();
        //    var teamsRatedGoalsAfter = homePage.GetRatedTeamsGoalsCount();
        //    Assert.AreEqual(teamsRatedGoalsBefore + 3, teamsRatedGoalsAfter);
        //}

        [Test]
        public void Manager_Can_Request_External_360Feedback()
        {
            TeamPage teamPage = new TeamPage(browser);

            teamPage.GoTo();
            teamPage.SelectTeamMember();
            teamPage.GoTo360FeedbackSection();
            teamPage.SendExternal360FeedbackRequest();
        }

        [Test]
        public void Manager_Can_Request_Internal_360Feedback()
        {
            TeamPage teamPage = new TeamPage(browser);

            teamPage.GoTo();
            teamPage.SelectTeamMember();
            teamPage.GoTo360FeedbackSection();
            //teamPage.SendInternal360FeedbackRequest();
        }
    }
}
