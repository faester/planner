using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlannerService.DataLayer;

namespace PlannerService
{
    class ConsoleLogger : ILogger
    {
        public void Debug(string p)
        {
            System.Diagnostics.Trace.WriteLine(p);
        }

        public void Info(string p)
        {
            System.Diagnostics.Trace.TraceInformation(p);
        }
    }
}
