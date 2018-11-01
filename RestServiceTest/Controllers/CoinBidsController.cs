using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace RestServiceTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinBidsController : ControllerBase
    {
        private static List<CoinBid> coinbidList = new List<CoinBid>
        {
            new CoinBid(1, "Gold DK 1640", 2500, "Mike"),
            new CoinBid(2, "Gold NL 1764", 5000, "Anbo"),
            new CoinBid(3, "Gold FR 1644", 0, "Auction"),
            new CoinBid(4,"Gold FR1644",3500,"Hammer"),
            new CoinBid(5,"Silver GR 333", 2500,"Mike")

        };

    // GET: api/CoinBids
        [HttpGet]
        public List<CoinBid> GetBids()
        {
            return coinbidList;
        }

        // GET: api/CoinBids/
        [HttpGet("{id}", Name = "GetOneBid")]
        public CoinBid GetId(int id)
        {
            foreach (CoinBid Coinbid in coinbidList)
            {
                if (id == Coinbid.Id)
                {
                    return Coinbid;
                }
            }
            //throw new ArgumentException("can't find id"); vil få programmmet til at lukke, hvis man taster forkert id
            return null;
        }

        // POST: api/CoinBids/
        [HttpPost]
        public void Post([FromBody] CoinBid coinbid)
        {
            coinbidList.Add(coinbid);
        }

        // PUT: api/CoinBids/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CoinBid coinbid)
        {
            
            foreach (CoinBid NCoinbid in coinbidList)
            {
                if (id == NCoinbid.Id)
                {
                    coinbidList.Remove(NCoinbid);
                    coinbidList.Add(NCoinbid);
                    return;
                }
            }

        }

        // DELETE: api/ApiWithActions/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (CoinBid coinbid in coinbidList)
            {
                if (id == coinbid.Id)
                {
                    coinbidList.Remove(coinbid);
                    return;
                }
            }
        }
    }
}
