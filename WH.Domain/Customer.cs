using System.Collections.Generic;
using System.Linq;

namespace WH.Domain
{


    public class Customer
    {
        public List<CustomerBet> Bets { get; set; }

        public int CustomerId { get; set; }

        public virtual bool IsHighRisk
        {
            get
            {
                               
                return WinPercentage > 60m;
            }
        }

        public decimal WinPercentage
        {
            get
            {
                if (Bets == null || !Bets.Any()) return 0;
                decimal winningBets = Bets.Count(x => x.Win > 0);
                decimal totalBets = Bets.Count;

                var percent = winningBets/totalBets*100m;
                return percent;
            }
        }

        public double AverageStake
        {
            get
            {
                if (Bets == null || !Bets.Any()) return 0;

                return Bets.Average(x => x.Stake);

            }
        }
    }
}