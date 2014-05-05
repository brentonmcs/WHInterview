using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WH.Data;
using WH.Data.Utilities;
using WH.Domain;

namespace WH.IntegrationTests
{
    [TestFixture]
    public class CsvImporterTests
    {        
        private List<CustomerBet> _customerBets;

        [SetUp]
        public void Setup()
        {
            var csvImporter = new CsvImporter();

            _customerBets = csvImporter.ReadFile("../../../../WH.Interview/App_Data/Settled.csv").ToList();
        }

        [Test]
        public void CheckRowCount()
        {

            Assert.AreEqual(50, _customerBets.Count());

        }

        [Test]
        public void TestWinSum()
        {
            Assert.AreEqual(9085, _customerBets.Sum(x => x.Win));

        }

        [Test]
        public void TestStakeSum()
        {
            Assert.AreEqual(2900, _customerBets.Sum(x => x.Stake));
        }

        [Test]
        public void TestParticipanteSum()
        {
            Assert.AreEqual(265, _customerBets.Sum(x => x.Participant));
        }

        [Test]
        public void TestEventSum()
        {
            Assert.AreEqual(274, _customerBets.Sum(x => x.Event));
        }

        [Test]
        public void TestCustomerSum()
        {
            Assert.AreEqual(158, _customerBets.Sum(x => x.Customer));
        }


    }
}
