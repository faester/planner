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
            ScheduleItem target = new ScheduleItem();

            target.Parent = new Event();
            target.Parent.Identifier = source.PartitionKey;
            target.Identifier = source.RowKey;
            target.EndTime = source.EndTime;
            target.StartTime = source.StartTime;
            target.Description = source.Description;

            return target;
        }

        public TSSchedule Convert(ScheduleItem source)
        {
            TSSchedule target = new TSSchedule();

            target.PartitionKey = source.Parent.Identifier;
            target.RowKey = source.Identifier;
            target.EndTime = source.EndTime;
            target.StartTime = source.StartTime;
            target.Description = source.Description;

            return target;
        }
    }
}