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

        internal DataLayer.IRepository<Event, RootItem> CreateEventRepository()
        {
            return DataLayer.TableStorageRepository.Create(new EventConverter());
        }

        internal DataLayer.IRepository<ScheduleItem, Event> CreateScheduleRepository()
        {
            return DataLayer.TableStorageRepository.Create(new ScheduleConverter());
        }

        internal DataLayer.ILogger GetLogger(Type type)
        {
            return new ConsoleLogger();
        }
    }
}