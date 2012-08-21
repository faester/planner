namespace PlannerService.DataLayer.TableEntityType
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using PlannerService.Models;

    public class TSEvent : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
        , RepositoryItem<Event, RootItem>
    {
        public string Identifier { get; set; }
    }
}