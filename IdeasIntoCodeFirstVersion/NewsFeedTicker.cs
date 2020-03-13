using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using IdeasIntoCodeFirstVersion.Interface;
using System.Threading;
using System.Collections.Concurrent;

namespace IdeasIntoCodeFirstVersion
{
    public class NewsFeedTicker
    {


       // // Singleton instance
       // private readonly static Lazy<NewsFeedTicker> _instance = new Lazy<NewsFeedTicker>(() => new NewsFeedTicker(GlobalHost.ConnectionManager.GetHubContext<NewsFeedTickerHub>().Clients));

       // private readonly ConcurrentDictionary<string, INewsFeed> _newsFeed = new ConcurrentDictionary<string, INewsFeed>();

       // private readonly object _updateStockPricesLock = new object();

       // //stock can go up or down by a percentage of this factor on each change
       //// private readonly double _rangePercent = .002;

       // private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
       // private readonly Random _updateOrNotRandom = new Random();

       // private readonly Timer _timer;
       // private volatile bool _updatingNewsFeedPosts = false;

       // private NewsFeedTicker(IHubConnectionContext<dynamic> clients)
       // {
       //     Clients = clients;

       //     _newsFeed.Clear();
       //     //var stocks = new List<INewsFeed>
       //     //{
       //     //    new Stock { Symbol = "MSFT", Price = 30.31m },
       //     //    new Stock { Symbol = "APPL", Price = 578.18m },
       //     //    new Stock { Symbol = "GOOG", Price = 570.30m }
       //     //};
       //     //stocks.ForEach(stock => _newsFeed.TryAdd(stock.Symbol, stock));

       //     _timer = new Timer(UpdateNewsFeed, null, _updateInterval, _updateInterval);

       // }

       // public static NewsFeedTicker Instance
       // {
       //     get
       //     {
       //         return _instance.Value;
       //     }
       // }

       // private IHubConnectionContext<dynamic> Clients
       // {
       //     get;
       //     set;
       // }

       // public IEnumerable<INewsFeed> GetAllStocks()
       // {
       //     return _newsFeed.Values;
       // }

        

       // private bool TryUpdateStockPrice(INewsFeed newsfeedpost)
       // {
       //     // Randomly choose whether to update this stock or not
       //     //var r = _updateOrNotRandom.NextDouble();
       //     //if (r > .1)
       //     //{
       //     //    return false;
       //     //}

       //     //// Update the stock price by a random factor of the range percent
       //     //var random = new Random((int)Math.Floor(stock.Price));
       //     //var percentChange = random.NextDouble() * _rangePercent;
       //     //var pos = random.NextDouble() > .51;
       //     //var change = Math.Round(stock.Price * (decimal)percentChange, 2);
       //     //change = pos ? change : -change;

       //     //stock.Price += change;
       //     return true;
       // }

       // private void BroadcastNewsFeed(INewsFeed newsFeed)
       // {
       //     Clients.All.updateStockPrice(newsFeed);
       // }

    }
}
