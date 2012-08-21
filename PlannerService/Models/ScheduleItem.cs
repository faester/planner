namespace PlannerService.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class ScheduleItem
        : IEventObject<Event>
    {
        public string Identifier { get; set; }

        public Event Parent { get; set; }

        DateTime StartTime { get; set; }
 
        DateTime EndTime { get; set; }
        
        string Description { get; set; }
    }
}