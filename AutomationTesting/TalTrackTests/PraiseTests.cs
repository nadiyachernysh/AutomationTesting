//using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class PraiseTests : TestBase
    {
        string receiverName = "Nadiya Chernysh";        
        
        [Test, Order(1)]
        public void Can_Send_Public_Praise()
        {
            PraisePage praisePage = new PraisePage(browser);
            PraiseDetailsPage praiseDetailsPage = new PraiseDetailsPage(browser);
            HomePage homePage = new HomePage(browser);
            
            praisePage.GoTo();
            //praisePage.SearchForAColleague(receiverName);
            praisePage.SelectColleague(); // can add number as input to select specific position in list
            var nameOfReceiver = praisePage.GetNameOfReceiver();
            praisePage.SendPraise();
            praisePage.AllDoneHere();

            var nameOfSender = homePage.GetNameOfSender();
            var lastPublicPraise = homePage.GetLastPublicPraise();
            Assert.AreEqual(nameOfSender + " sent praise to " + nameOfReceiver, lastPublicPraise);                        
        }

        //[Test, Order(2)]
        //public void Can_Receive_Praise()
        //{
        //    HomePage homePage = new HomePage(browser);
        //    LoginPage loginPage = new LoginPage(browser);
        //    PraisePage praisePage = new PraisePage(browser);

        //    loginPage.Logout();
        //    //loginPage.Login(receiverEmail, receiverPassword);
        //    praisePage.GoTo();
        //    praisePage.CheckLastReceivedPraise();

        //    Assert.That(senderName, Is.EqualTo(praisePage.LastPraiseWasReceivedFromName));
        //    //Assert.That("Just now", Is.EqualTo(praisePage.LastPraiseWasSentTime));
        //}

        [Test, Order(3)]
        public void Can_Add_Praise_To_Goal()
        {
            FeedbackPage feedbackPage = new FeedbackPage(browser);

            feedbackPage.GoTo();
            feedbackPage.SelectPraise();
            var titleOfSelectedGoal = feedbackPage.AddFeedbackToGoal();

            Assert.AreEqual(titleOfSelectedGoal, feedbackPage.GetTitleOfAttachedGoal());
        }

        [Test, Order(4)]
        public void Can_Detach_Praise_From_Goal()
        {
            FeedbackPage feedbackPage = new FeedbackPage(browser);

            feedbackPage.GoTo();
            feedbackPage.DetachFeedback();
                        
            Assert.True(feedbackPage.CheckThatFeedbackHasNoAttachedGoal());
        }

        [Test, Order(5)]
        public void Can_Send_Praise_Back()
        {
            FeedbackPage feedbackPage = new FeedbackPage(browser);
            PraisePage praisePage = new PraisePage(browser);
            HomePage homePage = new HomePage(browser);

            feedbackPage.GoTo();
            feedbackPage.SelectPraise();
            feedbackPage.SendPraiseBack();
            var nameOfReceiver = praisePage.GetNameOfReceiver();
            praisePage.SendPraise();
            praisePage.AllDoneHere();

            var nameOfSender = homePage.GetNameOfSender();
            var lastPublicPraise = homePage.GetLastPublicPraise();
            Assert.AreEqual(nameOfSender + " sent praise to " + nameOfReceiver, lastPublicPraise);
        }

        [Test, Order(6)]
        public void Can_Send_Private_Praise()
        {
            PraisePage praisePage = new PraisePage(browser);            
            HomePage homePage = new HomePage(browser);

            praisePage.GoTo();
            //praisePage.SearchForAColleague(receiverName);
            praisePage.SelectColleague();
            praisePage.SendPrivatePraise();

            homePage.GoTo();
            var lastPraise = homePage.GetBodyOfLastPublicPraise();
            Assert.AreNotEqual("Private", lastPraise);
        }

        [Test, Order(7)]
        public void Can_Search_For_Colleague()
        {
            PraisePage praisePage = new PraisePage(browser);            

            praisePage.GoTo();
            var receiverName = praisePage.GetNameOfReceiver();
            praisePage.SearchForAColleague(receiverName);

            Assert.AreEqual(receiverName, praisePage.GetNameOfReceiver());
        }
    }
    
}
