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
            var target = new Event();
            target.Identifier = source.RowKey;
            target.Parent = new RootItem();
            target.Parent.Identifier = source.PartitionKey;
            
            return target;
        }

        public TSEvent Convert(Event source)
        {
            var target = new TSEvent();

            target.PartitionKey = source.Parent.Identifier;
            target.RowKey = source.Identifier;
            target.Timestamp = DateTime.UtcNow;

            return target;
        }
    }
}