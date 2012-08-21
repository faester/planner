namespace PlannerService.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using PlannerService.Models;

    public interface IRepository<T, ParentType>
        where T : IEventObject<ParentType> 
        where ParentType : IdentifiableObject
    {
        void Init();

        IEnumerable<T> GetAll(string parentID);
       
        T Get(string identifier, string parentID);

        void Delete(string id, string parentId);

        void Add(T item);

        void Update(T item);
    }
}