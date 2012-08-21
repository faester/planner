using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlannerService.Models
{
    public interface IdentifiableObject
    {
        string Identifier { get; }
    }
}
