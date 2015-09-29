using App.SignalRSample.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace App.SignalRSample.Hubs
{
    public class PerformanceHub : Hub
    {
        public void SendPerformance(IList<PerformanceModel> performanceModels)
        {
            Clients.All.broadcastPerformance(performanceModels);
        }

        public void Heartbeat()
        {
            Clients.All.heartbeat();
        }

        public override Task OnConnected()
        {
            return (base.OnConnected());
        }
    }
}