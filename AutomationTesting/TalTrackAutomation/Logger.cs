using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTrackAutomation
{
    public class Logger
    {
        public static ILog Log = LogManager.GetLogger("TalTrackTests");
    }
}
