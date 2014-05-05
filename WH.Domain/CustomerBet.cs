using System.Collections.Generic;
using System.Linq;

namespace WH.Domain
{
    public class CustomerBet
    {
        public int Customer { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
        public int Win { get; set; }        
    }

    public class Customer
    {
        public List<CustomerBet> Bets { get; set; }

        public int CustomerId { get; set; }

        public bool IsHighRisk
        {
            get
            {
                if (Bets == null || !Bets.Any()) return false;

                decimal winningBets = Bets.Count(x => x.Win > 0);
                decimal totalBets = Bets.Count;

                var percent = winningBets / totalBets * 100m;
                return percent > 60m;
            }
        }
    }
}
