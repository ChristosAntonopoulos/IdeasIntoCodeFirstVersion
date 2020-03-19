using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdeasIntoCodeFirstVersion.Interface;
using IdeasIntoCodeFirstVersion.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace IdeasIntoCodeFirstVersion
{
    //[HubName("NewsFeedTickerMini")]
    public class NewsFeedTickerHub : Hub
    {
        private static readonly ConcurrentDictionary<string, UserHub> Users =
        new ConcurrentDictionary<string, UserHub>(StringComparer.InvariantCultureIgnoreCase);



        public override Task OnConnected()
        {
            string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;

            var user = Users.GetOrAdd(userName, _ => new UserHub
            {
                UserName = userName,
                ConnectionID = connectionId
            });
            if (user.ConnectionID != null)
            {
                Clients.Caller.userConnected(userName);
            }
            return base.OnConnected();
        }

        public void SendNotification(List<ApplicationUser> applicationUsers,INewsFeed newsFeed)
        {
            try
            {
                
                foreach (var applicationUser in applicationUsers)
                {
                    UserHub receiver;
                    if (Users.TryGetValue(applicationUser.Id, out receiver))
                    {
                        var cid = receiver.ConnectionID;
                        var context = GlobalHost.ConnectionManager.GetHubContext<NewsFeedTickerHub>();
                        context.Clients.Client(cid).broadcaastNotif(newsFeed);
                    }

                }

                
               
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }


        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    string userName = Context.User.Identity.Name;
        //    string connectionId = Context.ConnectionId;

        //    UserHubModels user;
        //    Users.TryGetValue(userName, out user);

        //    if (user != null)
        //    {
        //        lock (user.ConnectionIds)
        //        {
        //            user.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));
        //            if (!user.ConnectionIds.Any())
        //            {
        //                UserHubModels removedUser;
        //                Users.TryRemove(userName, out removedUser);
        //                Clients.Others.userDisconnected(userName);
        //            }
        //        }
        //    }

        //    return base.OnDisconnected(stopCalled);
        //}



    }


}