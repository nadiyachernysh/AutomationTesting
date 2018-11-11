using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation;
using NUnit.Framework;

namespace TalTrackTests
{
    [TestFixture]
    public class OKRsTests : TestBase
    {
        [Test, Order(1)]
        public void Can_Create_Own_OKR()
        {
            GoalsPage goalsPage = new GoalsPage(browser);
            OKRsPage okrsPage = new OKRsPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);

            goalsPage.GoTo();
            okrsPage.CreateOKR();
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();

            Assert.AreEqual("Created a Objective", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(okrsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }

        [Test, Order(2)]
        public void Can_Add_New_Key_Results()
        {
            GoalsPage goalsPage = new GoalsPage(browser);
            OKRsPage okrsPage = new OKRsPage(browser);
            ActivityFeedPage activityFeedPage = new ActivityFeedPage(browser);

            goalsPage.GoTo();
            okrsPage.AddNewKeyResult();
            activityFeedPage.ExpandActivityFeed();
            activityFeedPage.CheckNewUpdates();
            Assert.AreEqual("Edited a Objective", activityFeedPage.GetFirstCardAction());
            Assert.AreEqual(okrsPage.Title, activityFeedPage.GetFirstCardTitle());

            activityFeedPage.CloseActivityFeed();
        }
    }
}
