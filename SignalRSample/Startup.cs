// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="Barclays ">
//   Copyright © 2015 Barclays 
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

[assembly: Microsoft.Owin.OwinStartup(typeof(App.SignalRSample.Startup))]

namespace App.SignalRSample
{
    using App.SignalRSample.Engine;
    using Microsoft.AspNet.SignalR;
    using Owin;
    using System.Threading.Tasks;
    using Microsoft.Owin.Cors;


    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //// For more information on how to configure your application, visit:
            //// http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCors(CorsOptions.AllowAll);
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            app.MapSignalR(hubConfiguration);


            PerformanceEngine performanceEngine = new PerformanceEngine(800);
            Task.Factory.StartNew(async () => await performanceEngine.OnPerformanceMonitor());
    
            this.ConfigureAuth(app);
        }
    }
}
