using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlannerService.DataLayer.TableEntityType
{
    public interface RepositoryItem<PlannerServiceType, ParentType>
        where PlannerServiceType : Models.IEventObject<ParentType>
        where ParentType : Models.IdentifiableObject
    {
    }
}
