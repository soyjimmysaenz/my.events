using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Validation.Providers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EventosImportantes.Web.API.Filters;
using System.Data.Entity;
using EventosImportantes.Web.API.Handlers;
using EventosImportantes.Web.API.Models.Database;

namespace EventosImportantes.Web.API
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Filtro para manejo de errores
            GlobalConfiguration.Configuration.Filters.Add(new ValidationActionFilter());

            //Soporte para CORS
            GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());

            //Inicializar BD con datos
            Database.SetInitializer(new EventosDbInitializer());

            //serialización con JSON y remove de XML en response
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;

            GlobalConfiguration.Configuration.Services.RemoveAll(typeof(System.Web.Http.Validation.ModelValidatorProvider),
                                                                    v => v is InvalidModelValidatorProvider);
        }
    }
}