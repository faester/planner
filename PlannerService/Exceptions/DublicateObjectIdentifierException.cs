using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlannerService.Exceptions
{
    public class DublicateObjectIdentifierException
        : Exception
    {
        public DublicateObjectIdentifierException(string objectId, string parentId)
        {
            // TODO: Complete member initialization
            this.ObjectId = objectId;
            this.ParentId = parentId;
        }

        public string ParentId { get; private set; }

        public string ObjectId { get; private set; }
    }
}