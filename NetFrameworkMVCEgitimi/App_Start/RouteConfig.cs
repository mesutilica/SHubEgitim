using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NetFrameworkMVCEgitimi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", // url kısmı uygulama tarayıcıda çalıştığında site adından sonraki kısımda hangi controllerdaki hangi action ın çalıştırılacağını ayarlar.
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // defaults kısmı uygulama çalıştığında varsayılan anasayfa olarak hangi sayfanın çalıştırılacağını ayarlar.
            );
        }
    }
}
