// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Barclays ">
//   Copyright © 2015 Barclays 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.SignalRSample
{
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class Application : HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
