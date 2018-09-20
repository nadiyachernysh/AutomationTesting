using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTrackTests.Reporting
{
    //public class ReportingTasks
    //{
    //    private ExtentReports _extent;
    //    private ExtentTest _test;

    //    /// <summary>
    //    /// Initializes a new instance of the <see cref="ReportingTasks"/> class.
    //    /// </summary>
    //    /// <param name="extentInstance">The extent instance.</param>
    //    public ReportingTasks(ExtentReports extentInstance)
    //    {
    //        _extent = extentInstance;
    //    }

    //    /// <summary>
    //    /// Initializes the test for reporting.
    //    /// runs at the beginning of every test
    //    /// </summary>
    //    public void InitializeTest()
    //    {
    //        _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
    //    }

    //    /// <summary>
    //    /// Finalizes the test.
    //    /// Runs at the end of every test
    //    /// </summary>
    //    public void FinalizeTest()
    //    {
    //        var status = TestContext.CurrentContext.Result.Outcome.Status;
    //        var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
    //            ? ""
    //            : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);
    //        Status logstatus;

    //        switch (status)
    //        {
    //            case TestStatus.Failed:
    //                logstatus = Status.Fail;
    //                break;
    //            case TestStatus.Inconclusive:
    //                logstatus = Status.Warning;
    //                break;
    //            case TestStatus.Skipped:
    //                logstatus = Status.Skip;
    //                break;
    //            default:
    //                logstatus = Status.Pass;
    //                break;
    //        }
    //        _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
    //        //_extent.EndTest(_test);
    //        _extent.Flush();
    //    }

        /// <summary>
        /// Cleans up reporting.
        /// Runs after all the test finishes
        /// </summary>
        //public void CleanUpReporting()
        //{
        //    _extent.Close();
        //}
    //}
}

