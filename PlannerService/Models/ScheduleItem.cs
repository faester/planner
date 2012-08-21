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

        public DateTime StartTime { get; set; }
 
        public DateTime EndTime { get; set; }
        
        public string Description { get; set; }
    }
}