using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using WH.Business.Services;
using WH.Data;
using WH.Domain;

namespace WH.UnitTests.Service
{
    public class RiskServiceTest
    {
        [Test]
        public void CustomerBetsGroupedCorrectly()
        {
            var betData = A.Fake<BetData>();
            var customerService = new RiskService(betData);

            A.CallTo(() => betData.ResultedBets).Returns(new List<CustomerBet>
            {
                new CustomerBet {Customer = 1},
                new CustomerBet {Customer = 1},
                new CustomerBet {Customer = 2}
            });

            var customers = customerService.Customers;
            Assert.AreEqual(2,customers.Count);            
            Assert.AreEqual(customers.First(x=>x.CustomerId == 1).Bets.Count,2);
        }
        
        [Test]
        public void CustomerBetsHandlesNull()
        {
            var betData = A.Fake<BetData>();
            var customerService = new RiskService(betData);

            A.CallTo(() => betData.ResultedBets).Returns(null);

            var customers = customerService.Customers;
            Assert.AreEqual(0, customers.Count);            

            
        }
        
    }
}
