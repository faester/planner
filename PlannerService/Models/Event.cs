using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlannerService.Models
{
    public class Event
        : IEventObject<RootItem>
    {
        public string Identifier { get; set; }

        public RootItem Parent { get; set; }
    }
}