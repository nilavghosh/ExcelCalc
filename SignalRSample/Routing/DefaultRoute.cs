// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRoute.cs" company="Barclays ">
//   Copyright © 2015 Barclays 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace App.SignalRSample.Routing
{
    using System.Web.Routing;

    public class DefaultRoute : Route
    {
        public DefaultRoute()
            : base("{*path}", new DefaultRouteHandler())
        {
            this.RouteExistingFiles = false;
        }
    }
}
