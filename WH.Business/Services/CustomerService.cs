using System.Collections.Generic;
using System.Linq;
using WH.Data;
using WH.Domain;

namespace WH.Business.Services
{
    public class CustomerService
    {
        private readonly BetData _betData;

        public CustomerService(BetData betData)
        {
            _betData = betData;
        }

        public virtual List<Customer> Customers
        {
            get
            {
                var resultedBets = _betData.ResultedBets;

                var customers = resultedBets.Select(x => x.Customer).Distinct();

                return customers.Select(customerId => new Customer
                {
                    CustomerId = customerId,
                    Bets = resultedBets.Where(x => x.Customer == customerId).ToList()
                }).ToList();
            }
        }

        public IEnumerable<Customer> HighRiskCustomers
        {
            get { return Customers.Where(x => x.IsHighRisk); }
        }
    }
}