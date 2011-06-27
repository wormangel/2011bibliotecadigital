using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Arquivo", // Route name
               "DocumentoArquivistico/{idDocArq}/Volume/{idVol}/Documento/{idDoc}/Arquivo/{action}/{id}", // URL with parameters
               new { controller = "Arquivo", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Documento", // Route name
                "DocumentoArquivistico/{idDocArq}/Volume/{idVol}/Documento/{action}/{id}", // URL with parameters
                new { controller = "Documento", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Volume", // Route name
                "DocumentoArquivistico/{idDocArq}/Volume/{action}/{id}", // URL with parameters
                new { controller = "Volume", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Subgrupo", // Route name
                "Classe/{idClasse}/Subclasse/{idSubclasse}/Grupo/{idGrupo}/Subgrupo/{action}/{id}", // URL with parameters
                new { controller = "Subgrupo", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Grupo", // Route name
                "Classe/{idClasse}/Subclasse/{idSubclasse}/Grupo/{action}/{id}", // URL with parameters
                new { controller = "Grupo", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Subclasse", // Route name
                "Classe/{idClasse}/Subclasse/{action}/{id}", // URL with parameters
                new { controller = "Subclasse", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "VersaoDocumentoArquivistico", // Route name
                "DocumentoArquivistico/{idDocArq}/Versao/{idVersao}", // URL with parameters
                new { controller = "DocumentoArquivistico", action = "Versao", idVersao = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "VersaoVolume", // Route name
                "Volume/{idVolume}/Versao/{idVersao}", // URL with parameters
                new { controller = "Volume", action = "Versao", idVersao = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "VersaoDocumento", // Route name
                "Documento/{idDocumento}/Versao/{idVersao}", // URL with parameters
                new { controller = "Documento", action = "Versao", idVersao = UrlParameter.Optional } // Parameter defaults
            );
            
            routes.MapRoute(
                "Default", // Route name  (Classe)
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}