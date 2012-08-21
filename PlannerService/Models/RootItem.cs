using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlannerService.Models
{
    public class RootItem
        : IdentifiableObject
    {
        public string Identifier
        {
            get;
            private set;
        }

        private RootItem() { }

        public static readonly RootItem Root
            = new RootItem() { Identifier = "root" };
        
    }
}