using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestServiceTest.Controllers;
using RestServiceTest;

namespace RestCustomerServiceTest
{

    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void GetOne()
        {
            CoinBidsController cc = new CoinBidsController();
            //Customer c = new Customer(1, "Knud", "dunk", 2019);

            Assert.AreEqual("Mike", cc.GetId(1).Navn);
        }

        public void GetAll()
        {
            CoinBidsController cc = new CoinBidsController();
            List<CoinBid> cList = cc.GetBids();
            Assert.AreEqual("Mike", cList[0].Navn);

        }

        [TestMethod]
        public void Post()
        {
            CoinBidsController cc = new CoinBidsController();
            CoinBid cToPost = new CoinBid(6, "Gold SE 3000", 5000, "Mik");
            cc.Post(cToPost);
            Assert.AreEqual(cToPost.Navn, cc.GetId(cToPost.Id).Navn);
        }

        [TestMethod]
        public void Put()
        {
            CoinBidsController cc = new CoinBidsController();
            CoinBid cToPut = new CoinBid(6, "Gold SE 3000", 5000, "Mik");
            cc.Put(cToPut.Id, cToPut);
            Assert.AreEqual(cToPut.Navn, cc.GetId(cToPut.Id).Navn);
        }

        [TestMethod]
        public void Delete()
        {
            CoinBidsController cc = new CoinBidsController();
            //Customer cToPost = new Customer(100, "Dang", "brutha", 2080);
            //cc.Post((cToPost));
            cc.Delete(1);
            CoinBid cGet = cc.GetId(1);
            Console.WriteLine(cGet);
            Assert.IsNull(cGet);
        }
    }
}

