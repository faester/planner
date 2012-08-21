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
    public class EventController : ApiController
    {
        public IRepository<Event, RootItem> CreateController()
        {
            return PlannerConfiguration.CreateEventRepository();
        }

        // GET api/event/parentId
        public IEnumerable<Event> Get()
        {
            yield return new Event { Identifier = "a", Parent = RootItem.Root };
            yield return new Event { Identifier = "b", Parent = RootItem.Root };
            yield return new Event { Identifier = "c", Parent = RootItem.Root };
            yield return new Event { Identifier = "d", Parent = RootItem.Root };
        }

        // GET api/event/parentId
        public Event Get(string id)
        {
            return new Event { Identifier = id, Parent = RootItem.Root };
        }

        // POST api/event
        public void Post(string id, string value)
        {
        }

        // PUT api/event/5
        public void Put(string id, string value)
        {
        }

        // DELETE api/event/5
        public void Delete(int id)
        {
        }
    }
}
