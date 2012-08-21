using System;
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
        where ParentType : IdentifiableObject, new()
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
        public void Post(string parentId, T value)
        {
            if (value.Parent == null)
            {
                value.Parent = new ParentType();
            }

            value.Parent.Identifier = parentId;

            CreateRepository().Add(value);
        }

        // PUT api/abstract/5
        public void Put(string parentId, string id, T value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            if (value.Parent == null) { throw new ArgumentNullException("parent"); }

            value.Identifier = id;
            value.Parent.Identifier = parentId;

            CreateRepository().Update(value);
        }

        // DELETE api/abstract/5
        public void Delete(string parentId, string id)
        {
            CreateRepository().Delete(parentId, id);
        }
    }
}
