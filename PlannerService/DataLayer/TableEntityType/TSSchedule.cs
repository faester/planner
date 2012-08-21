using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlannerService.DataLayer.TableEntityType
{
    public class TSSchedule
        : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
        , RepositoryItem<Models.ScheduleItem, Models.Event> 
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Description { get; set; }
    }
}