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
        private static readonly ConcurrentDictionary<string, string> Users =
        new ConcurrentDictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);



        public void Connect(string userid)
        {

            Users.GetOrAdd(userid, Context.ConnectionId);
        }

        public void SendNotification(List<ApplicationUser> applicationUsers,INewsFeed newsFeed)
        {
            try
            {
                
                foreach (var applicationUser in applicationUsers)
                {
                    string receiverConnectionString;
                    if (Users.TryGetValue(applicationUser.Id, out receiverConnectionString))
                    {
                        var cid = receiverConnectionString;
                        //var context = GlobalHost.ConnectionManager.GetHubContext<NewsFeedTickerHub>();
                        Clients.Client(cid).broadcaastNotif(newsFeed);
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