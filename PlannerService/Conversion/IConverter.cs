using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PlannerService.Models;

namespace PlannerService.Conversion
{
    public interface IConverter<TSType, PlannerType, ParentType>
        where PlannerType : Models.IEventObject<ParentType>
        where TSType : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
        where ParentType : IdentifiableObject
    {
        PlannerType Convert(TSType source);
        TSType Convert(PlannerType source);
    }
}