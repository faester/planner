namespace PlannerService.Conversion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using PlannerService.DataLayer.TableEntityType;
    using PlannerService.Models;

    public class ScheduleConverter
        : IConverter<TSSchedule, ScheduleItem, Event>
    {


        public ScheduleItem Convert(TSSchedule source)
        {
            throw new NotImplementedException();
        }

        public TSSchedule Convert(ScheduleItem source)
        {
            throw new NotImplementedException();
        }
    }
}