using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalR.Models;

namespace SignalR.HubClient
{
    public class ProductHub : Hub
    {
        public void Echo(string message)
        {
            Clients.All.SendAsync("Send", message);
        }


        // public async Task NewProduct(Product product)
        // {
        //     await Clients.All.SendAsync("ProductPublished", product);
        // }

        //  public async Task NewProduct(Product product)
        // {
        // public override Task OnConnected()
        // {
        //     return base.OnConnected();
        // }

        // public override Task OnDisconnected(bool stopCalled)
        // {
        //     return base.OnDisconnected(stopCalled);
        // }
    }
}