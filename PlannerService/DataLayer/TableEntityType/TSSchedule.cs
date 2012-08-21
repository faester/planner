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
        DateTime StartTime { get; set; }

        DateTime EndTime { get; set; }

        string Description { get; set; }
    }
}