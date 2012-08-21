using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlannerService.Models;

namespace PlannerService.Controllers
{
    public class ScheduleController : AbstractController<ScheduleItem, Event>
    {
        protected override DataLayer.IRepository<ScheduleItem, Event> CreateRepository()
        {
            return PlannerConfiguration.Configuration.CreateScheduleRepository();
        }
    }
}
