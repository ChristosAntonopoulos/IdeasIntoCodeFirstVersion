using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using IdeasIntoCodeFirstVersion.DTOs;
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

       

        public void Connect(string devId)
        {
             
            Users.GetOrAdd(devId, Context.ConnectionId);
        }

        public void SendNotification(List<Developer> developersToNotify,INewsFeed newsFeed,Developer developerOfNotification, FilePathResult pic)
        {
            try
            {
                
                foreach (var developer in developersToNotify)
                {
                    string receiverConnectionString;
                    if (Users.TryGetValue(developer.ID.ToString(), out receiverConnectionString))
                    {
                        //var cid = receiverConnectionString;
                        var project = (newsFeed as Project);
                       
                        //var bob = Directory.GetFiles("/Content/Images/dev").Select(Path.GetFileName);
                        var context = GlobalHost.ConnectionManager.GetHubContext<NewsFeedTickerHub>();
                        var projectDto = Mapper.Map<Project, ProjectDto>(project);
                         context.Clients.Client(receiverConnectionString).getProjectNotification(projectDto, developerOfNotification.User.FullName,pic);
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