using System.Collections.Generic;
using NUnit.Framework;
using WH.Domain;

namespace WH.UnitTests.Domain
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void HighRiskWhenNullBetsReturnsFalse()
        {
            var customer = new Customer();

            Assert.IsFalse(customer.IsHighRisk);
        }

        [Test]
        public void HighRiskWhenNoBetsReturnsFalse()
        {
            var customer = new Customer {Bets = new List<CustomerBet>()};
            Assert.IsFalse(customer.IsHighRisk);
        }

        [Test]
        public void HighRiskWhenNoWinningReturnsFalse()
        {
            var customer = new Customer { Bets = new List<CustomerBet> { new CustomerBet { Win = 0}} };
            Assert.IsFalse(customer.IsHighRisk);
        }

        [Test]
        public void HighRiskWhenOneWinningReturnsTrue()
        {
            var customer = new Customer { Bets = new List<CustomerBet> { new CustomerBet { Win = 1 } } };
            Assert.IsTrue(customer.IsHighRisk);
        }

        [Test]
        public void HighRiskWithExactly60PercentWinningReturnsFalse()
        {
            var customer = new Customer
            {
                Bets = new List<CustomerBet>
                {
                    new CustomerBet { Win = 1 }, 
                    new CustomerBet { Win = 1 }, 
                    new CustomerBet { Win = 1 }, 
                    new CustomerBet { Win = 1 },                     
                    new CustomerBet { Win = 1 }, 
                    new CustomerBet { Win = 1 }, 
                    
                    new CustomerBet { Win = 0 },
                    new CustomerBet { Win = 0 },
                    new CustomerBet { Win = 0 },
                    new CustomerBet { Win = 0 }
                
                }
            };
            Assert.IsFalse(customer.IsHighRisk);
        }

        [Test]
        public void HighRiskWithExactly70PercentWinningReturnsTrue()
        {
            var customer = new Customer
            {
                Bets = new List<CustomerBet>
                {
                    new CustomerBet { Win = 1 }, 
                    new CustomerBet { Win = 1 }, 
                    new CustomerBet { Win = 1 }, 
                    new CustomerBet { Win = 1 },                     
                    new CustomerBet { Win = 1 }, 
                    new CustomerBet { Win = 1 },                     
                    new CustomerBet { Win = 1 },

                    new CustomerBet { Win = 0 },
                    new CustomerBet { Win = 0 },
                    new CustomerBet { Win = 0 }
                
                }
            };
            Assert.IsTrue(customer.IsHighRisk);
        }

        [Test]
        public void AverageStakeReturnsValidAmount()
        {
            var customer = new Customer
            {
                Bets = new List<CustomerBet>
                {
                    new CustomerBet {Stake = 10},
                    new CustomerBet {Stake = 10},
                }
            };

            Assert.AreEqual(10,customer.AverageStake);
        }
    }
}
