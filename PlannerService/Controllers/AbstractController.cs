﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlannerService.Models;

namespace PlannerService.Controllers
{
    public abstract class AbstractController<T, ParentType> : ApiController
        where T : Models.IEventObject<ParentType>
        where ParentType : IdentifiableObject
    {
        protected abstract DataLayer.IRepository<T, ParentType> CreateRepository();

        // GET api/abstract
        public IEnumerable<T> Get(string parentId)
        {
            return CreateRepository().GetAll(parentId);
        }

        // GET api/abstract/5
        public T Get(string parentId, string id)
        {
            return CreateRepository().Get(id, parentId);
        }

        // POST api/abstract
        public void Post(T value)
        {
            CreateRepository().Add(value);
        }

        // PUT api/abstract/5
        public void Put(string parentId, string id, T value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            if (value.Parent == null) { throw new ArgumentNullException("parent"); }
            if (value.Identifier != id) { throw new ArgumentException("id"); }
            if (value.Parent.Identifier != id) { throw new ArgumentException("parent.id"); }

            CreateRepository().Update(value);
        }

        // DELETE api/abstract/5
        public void Delete(string parentId, string id)
        {
            CreateRepository().Delete(parentId, id);
        }
    }
}
