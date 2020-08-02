using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AngularSignalR
{
  public class EchoHub : Hub
  {
    public void Echo(string message)
    {
      Clients.All.SendAsync("Send", message);
    }
  }
}