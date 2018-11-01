using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using ClassLibrary;
using Newtonsoft.Json;

namespace RestCoinConsumer12
{
    class RestHandler
    {
        private String CustomerURI = "http://localhost:59448/api/CoinBids/";

        public RestHandler()
        {
        }

        public void Start()
        {
            Console.WriteLine("Get All Bids");
            var cList = GetBids();
            foreach (CoinBid coinbid in cList)
            {
                Console.WriteLine(coinbid);
            }
            Console.WriteLine("Get Bid No 3");
            var coin = GetBidById(3);
            Console.WriteLine(coin);

        }

        public IList<CoinBid> GetBids()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(CustomerURI).Result;
                IList<CoinBid> cList = JsonConvert.DeserializeObject<IList<CoinBid>>(content);
                return cList;
            }
        }

        public CoinBid GetBidById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(CustomerURI + id).Result;
                CoinBid coin = JsonConvert.DeserializeObject<CoinBid>(content);
                return coin;
            }
        }
        
    }
}
