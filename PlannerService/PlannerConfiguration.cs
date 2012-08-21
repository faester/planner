using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlannerService.Conversion;
using PlannerService.DataLayer.TableEntityType;
using PlannerService.Models;

namespace PlannerService
{
    public class PlannerConfiguration
    {
        static PlannerConfiguration()
        {
            Configuration = new PlannerConfiguration();
        }

        public static PlannerConfiguration Configuration
        {
            get;
            set;
        }

        internal static DataLayer.IRepository<Event, RootItem> CreateEventRepository()
        {
            return DataLayer.TableStorageRepository.Create(Conversion.AutoConverter.Create<TSEvent, Event, RootItem>());
        }

        internal static DataLayer.IRepository<ScheduleItem, Event> CreateScheduleRepository()
        {
            return DataLayer.TableStorageRepository.Create(Conversion.AutoConverter.Create<TSSchedule, ScheduleItem, Event>());
        }
    }
}