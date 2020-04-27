using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fis.Ui.NotificationCenter
{
    public class NotifyEnquiry:Hub
    {
        public async Task NewEnquiry(long username, string message)
        {
            await Clients.All.SendAsync("NewEnquiryArrived", username, message);
        }

    }
}
