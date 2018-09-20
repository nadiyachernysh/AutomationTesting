using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using log4net.Config;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using TalTrackAutomation;

namespace TalTrackTests
{
    public class TestBase
    {
        protected Browser browser;
        protected ExtentReports _extent;
        protected ExtentTest _test;
        private string _path;
        
        [OneTimeSetUp]
        public void BeforeSuit()
        {
            XmlConfigurator.Configure();

            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(dir + fileName);

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);

            this.browser = new Browser();
            browser.Initialize();
            LoginPage loginPage = new LoginPage(browser);
            loginPage.CopyCreds();
            loginPage.Login();    
                     
        }

        [OneTimeTearDown]
        protected void AfterSuit()
        {
            LoginPage loginPage = new LoginPage(browser);
            loginPage.Logout();
            browser.Close();
            _extent.Flush();             
        }

        [SetUp]
        public void Init()
        {            
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);            
        }

        [TearDown]
        public void Cleanup()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                _path = browser.TakeScreenshot(TestContext.CurrentContext.TestDirectory); //, TestContext.CurrentContext.Test.Name                  
            }

            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    _test.Log(logstatus, "Test ended with " + logstatus + " and message: " + message);
                    _test.Log(logstatus, "Snapshot below: " + _test.AddScreenCaptureFromPath(_path));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    _test.Log(logstatus, "Test ended with " + logstatus + " and message: " + message);
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    _test.Log(logstatus, "Test ended with " + logstatus + " and message: " + message);
                    break;
                default:
                    logstatus = Status.Pass;
                    _test.Log(logstatus, "Test ended with " + logstatus);
                    break;
            }

            // + "Stacktrace is :" + stacktrace   
        }
        
    }
}
