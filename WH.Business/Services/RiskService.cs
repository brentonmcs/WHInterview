using System.Collections.Generic;
using System.Linq;
using WH.Data;
using WH.Domain;

namespace WH.Business.Services
{
    public class RiskService
    {
        private readonly BetData _betData;

        private List<Bet> _bets;
        private List<Customer> _customers;

        public RiskService(BetData betData)
        {
            _betData = betData;
        }

        public List<Bet> Bets
        {
            get
            {
                return _bets = _bets ?? LoadBets();
            }
        }

        public virtual List<Customer> Customers
        {
            get
            {
                return _customers = _customers ?? LoadCustomers();
            }
        }

        public IEnumerable<Bet> HighRiskBets
        {
            get
            {
                return Bets.Where(x => x.RiskLevel != RiskLevel.Normal);
            }
        }

        public IEnumerable<Customer> HighRiskCustomers
        {
            get
            {
                return Customers.Where(x => x.IsHighRisk);
            }
        }

        private List<Bet> LoadBets()
        {
            return _betData.ResultedBets.Select(x => new Bet
            {
                ParticipantId = x.Participant,
                EventId = x.Event,
                Stake = x.Stake,
                WinAmount = x.Win,
                Customer = Customers.First(y => y.CustomerId == x.Customer)
            }).ToList();
        }

        private List<Customer> LoadCustomers()
        {
            var resultedBets = _betData.ResultedBets;

            if (resultedBets == null)
                return new List<Customer>();

            var customers = resultedBets.Select(x => x.Customer).Distinct();

            return customers.Select(customerId => new Customer
            {
                CustomerId = customerId,
                Bets = resultedBets.Where(x => x.Customer == customerId).ToList()
            }).ToList();
        }
    }
}