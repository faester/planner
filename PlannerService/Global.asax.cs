namespace PlannerService
{
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using PlannerService.Formatters;
    using PlannerService.Models;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Compose(GlobalConfiguration.Configuration);
        }

        private void Compose(HttpConfiguration httpConfiguration)
        {
            ComposablePartCatalog catalog =
                new System.ComponentModel.Composition.Hosting.AssemblyCatalog(GetType().Assembly);

            CompositionContainer container = new CompositionContainer(catalog);
            CompositionBatch batch = new CompositionBatch();

            Register(httpConfiguration);
        }

        private void Register(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Formatters.Add(new HtmlFormatter());
            HtmlFormatter.AddHtmlConverter<PersonConverter, Person>();
        }
    }
}