using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTrackTests.Reporting
{
    //Creates a single instance of Extent Report
    public class ReportingManager
    {
        private static readonly ExtentReports _instance = new ExtentReports();

        static ReportingManager()
        {
            var htmlReporter = new ExtentHtmlReporter("TestResults.html");//TestContext.CurrentContext.TestDirectory + 
            Instance.AttachReporter(htmlReporter);
        }
        private ReportingManager() { }

        /// <summary>
        /// Property to return the instance of the report.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ExtentReports Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
