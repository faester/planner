using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlannerService.DataLayer
{
    public interface ILogger
    {
        void Debug(string p);

        void Info(string p);
    }
}
