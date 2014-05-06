using System.Collections.Generic;
using NUnit.Framework;
using WH.Domain;

namespace WH.UnitTests.Domain
{
    [TestFixture]
    public class BetTests
    {
        private Bet _bet;

        [SetUp]
        public void Setup()
        {
            _bet = new Bet();            
        }

        
        [Test]
        public void RiskLevelWithNoCustomerReturnsNormal()
        {
            Assert.AreEqual(RiskLevel.Normal, _bet.RiskLevel);
        }

        [Test]
        public void RiskLevelWithLowStakeIsNormal()
        {
            _bet.Customer = GetCustomerWithAverage(100);
            _bet.Stake = 100;
            Assert.AreEqual(RiskLevel.Normal, _bet.RiskLevel);
        }

        [Test]
        public void RiskLevelWithExactly10TimesStakeIsNormal()
        {
            _bet.Customer = GetCustomerWithAverage(100);
            _bet.Stake = 1000;
            Assert.AreEqual(RiskLevel.Normal, _bet.RiskLevel);
        }

        [Test]
        public void RiskLevelWithOver10TimesStakeIsUnusual()
        {
            _bet.Customer = GetCustomerWithAverage(100);
            _bet.Stake = 1001;
            Assert.AreEqual(RiskLevel.Unusual, _bet.RiskLevel);
        }

        [Test]
        public void RiskLevelWithExactly30TimesStakeIsUnusual()
        {
            _bet.Customer = GetCustomerWithAverage(100);
            _bet.Stake = 100 * 30;
            Assert.AreEqual(RiskLevel.Unusual, _bet.RiskLevel);
        }

        [Test]
        public void RiskLevelWithOver30TimesStakeIsHigh()
        {
            _bet.Customer = GetCustomerWithAverage(100);
            _bet.Stake = 100 * 30 + 1;
            Assert.AreEqual(RiskLevel.High, _bet.RiskLevel);
        }

        [Test]
        public void RiskLevelWithLowAverageButHighWinRateIsHigh()
        {
            _bet.Customer = GetCustomerWithAverage(100);
            _bet.Stake = 100 * 10;
            _bet.WinAmount = 1001;
            Assert.AreEqual(RiskLevel.High, _bet.RiskLevel);
        }

        private static Customer GetCustomerWithAverage(int averageBetSize)
        {
            return new Customer
            {
                Bets = new List<CustomerBet>
                {
                    new CustomerBet {Stake = averageBetSize},
                }
            };
        }
    }
}