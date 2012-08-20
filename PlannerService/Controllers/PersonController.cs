namespace PlannerService.Controllers
{
    using System.Web.Http;
    using System.Web.Mvc;
    using PlannerService.Models;

    public class PersonController : ApiController
    {
        //
        // GET: /Person/

        public Person GetPerson(string id)
        {
            var person = new Person { ID = id, Name = "Person " + id };

            return person;
        }
    }
}
