namespace PlannerService.Conversion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using PlannerService.DataLayer.TableEntityType;
    using PlannerService.Models;

    public class EventConverter
         : IConverter<TSEvent, Event, RootItem>
    {
        public Event Convert(TSEvent source)
        {
            throw new NotImplementedException();
        }

        public TSEvent Convert(Event source)
        {
            throw new NotImplementedException();
        }
    }
}