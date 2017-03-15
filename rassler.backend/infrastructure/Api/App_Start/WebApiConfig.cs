using System.Web.Http;
using AutoMapper;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using rassler.backend.domain.Model;
using rassler.backend.infrastructure.Api.Interfaces;
using rassler.backend.infrastructure.Api.Services;
using rassler.backend.infrastructure.Api.Utilities;
using rassler.backend.infrastructure.Database;
using rassler.backend.infrastructure.Database.Interfaces;
using rassler.backend.infrastructure.Database.Services;

namespace rassler.backend.infrastructure.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
