// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Barclays ">
//   Copyright © 2015 Barclays 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.SignalRSample
{
    using System.Web.Routing;

    using App.SignalRSample.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add("Default", new DefaultRoute());
        }
    }
}
