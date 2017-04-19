using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAISTGolfCourse.Web.Hubs
{
    public class MemberChatHub : Hub
    {
        public void Send(string currentUserName, string message)
        {
            string dateTime = DateTime.Now.ToShortTimeString();

            Clients.All.addMessageToDiv(dateTime, currentUserName, message);
        }
    }
}