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
            set;
        }

        public RootItem() {
            Identifier = Root.Identifier;
        }

        private RootItem(string id)
        {
            Identifier = id;
        }

        public static readonly RootItem Root
            = new RootItem("root");
    }
}