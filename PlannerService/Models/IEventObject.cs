using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlannerService.Models
{
    public interface IEventObject<ParentType> : IdentifiableObject
        where ParentType : IdentifiableObject
    {
        ParentType Parent { get; set; }
    }
}