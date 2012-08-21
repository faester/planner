using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlannerService.Models;

namespace PlannerService.Controllers
{
    public class ScheduleController : ApiController
    {
        // GET api/schedule
        public IEnumerable<ScheduleItem> Get(string parentId)
        {
            var parent = new Event {Identifier = parentId, Parent = RootItem.Root};
            yield return new ScheduleItem { Identifier = "sched a", Parent = parent };
            yield return new ScheduleItem { Identifier = "sched b", Parent = parent };
            yield return new ScheduleItem { Identifier = "sched c", Parent = parent };
            yield return new ScheduleItem { Identifier = "sched d", Parent = parent };
            yield return new ScheduleItem { Identifier = "sched e", Parent = parent };
        }

        // GET api/schedule/5
        public ScheduleItem Get(string parentId, string id)
        {
            var parent = new Event { Identifier = parentId, Parent = RootItem.Root };

            return new ScheduleItem { Identifier = id, Parent = parent };
        }

        // POST api/schedule
        public void Post(string value)
        {
        }

        // PUT api/schedule/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/schedule/5
        public void Delete(int id)
        {
        }
    }
}
