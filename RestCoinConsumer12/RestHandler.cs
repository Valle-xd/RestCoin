using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using ClassLibrary;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace RestCoinConsumer12
{
    class RestHandler
    {
        private String URI = "http://localhost:59448/api/CoinBids/";

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

            Console.WriteLine("Add a new bid");
            bool newBid = CreateNewBid(new CoinBid(6, "Diamond GG 553", 6000, "joe"));
            Console.WriteLine("new bid was added = " + newBid);


            Console.WriteLine("Update Bid");
            var isUpdated = UpdateBid(6, new CoinBid(6, "Diamond GG 553", 9990, "joe"));
            Console.WriteLine("was updated " + isUpdated);
            cList = GetBids();
            Console.WriteLine(cList.Last());
        }

        public IList<CoinBid> GetBids()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(URI).Result;
                IList<CoinBid> cList = JsonConvert.DeserializeObject<IList<CoinBid>>(content);
                return cList;
            }
        }

        public CoinBid GetBidById(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(URI + id).Result;
                CoinBid coin = JsonConvert.DeserializeObject<CoinBid>(content);
                return coin;
            }
        }

        public bool CreateNewBid(CoinBid bid)
        {
            // prepare the bid to be send in the body as content
            // convert the bid object into a json string and create the content (body)
            String jsonStr = JsonConvert.SerializeObject(bid);
            StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            bool succed = false;

            // setup to use HTTP as transport for a REST request
            using (HttpClient client = new HttpClient())
            {
                // send a REST POST request ie. creating
                HttpResponseMessage response = client.PostAsync(URI, content).Result;
                // check if it succeded
                if (response.IsSuccessStatusCode)
                {
                    // get the result as json string and convert it into an boolean
                    String jsonRes = response.Content.ReadAsStringAsync().Result;
                    succed = JsonConvert.DeserializeObject<bool>(jsonRes);
                }
            }

            return succed;
        }
        private bool UpdateBid(int id, CoinBid coinBid)
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonStr = JsonConvert.SerializeObject(coinBid);
                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(URI + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string resultStr = response.Content.ReadAsStringAsync().Result;
                    bool result = JsonConvert.DeserializeObject<bool>(resultStr);
                    return result;
                }
                return false;

            }
        }
    }
}
