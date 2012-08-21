using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlannerService.DataLayer;
using PlannerService.Models;

namespace PlannerService.Controllers
{
    public class EventController : AbstractController<Event, RootItem>
    {
        protected override IRepository<Event, RootItem> CreateRepository()
        {
            return PlannerConfiguration.Configuration.CreateEventRepository();
        }
    }
}
