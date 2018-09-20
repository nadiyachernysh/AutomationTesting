using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalTrackAutomation;
using TalTrackAutomation.Pages;

namespace TalTrackTests
{
    [TestFixture]
    public class CheckInTests : TestBase
    {
        [Test,Order(1)]
        public void Can_Preview_CheckIn()
        {            
            CheckInPage checkInPage = new CheckInPage(browser);

            checkInPage.GoTo();
            checkInPage.OpenUnsubmittedCheckIn();
            browser.SwitchToNewTab();
            checkInPage.OpenReviewGoals();
            checkInPage.AddCommentToGoal();
            checkInPage.AddPerformanceComment();
            checkInPage.AddStepsComment();

            var commentEntered = checkInPage.GetCommentAboutSteps();
            checkInPage.PreviewCheckIn();

            var commentInPreview = checkInPage.GetCommentAboutSteps();
            Assert.AreEqual(commentEntered, commentInPreview);
        }

        [Test, Order(2)]
        public void Can_Edit_CheckIn()
        {
            CheckInPage checkInPage = new CheckInPage(browser);

            checkInPage.Edit();
            var commentEntered = checkInPage.GetCommentAboutSteps();
            checkInPage.PreviewCheckIn();

            var commentInPreview = checkInPage.GetCommentAboutSteps();
            Assert.AreEqual(commentEntered, commentInPreview);
        }

        [Test, Order(3)]
        public void Can_Submit_CheckIn()
        {
            CheckInPage checkInPage = new CheckInPage(browser);

            checkInPage.Submit();
            var confirmation = checkInPage.GetConfirmationText();

            Assert.AreEqual("Your notes are now saved on the check-in section of TalTrack.", confirmation);
        }

        [Test, Order(4)]
        public void Can_See_CheckIn_Results()
        {
            CheckInPage checkInPage = new CheckInPage(browser);

            checkInPage.GoBack();
            var checkInHeader = checkInPage.GetCheckInHeader();            

            //Assert.AreEqual("Check-in Meeting Notes " + DateTime.Now.ToString("dd MMMM, yyyy"), checkInHeader);
        }

    }
}
