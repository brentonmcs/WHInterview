namespace WH.Domain
{
    public class Bet
    {        
        public int EventId { get; set; }

        public int Stake { get; set; }

        public int WinAmount { get; set; }
        
        public int ParticipantId { get; set; }
        public Customer Customer { get; set; }
        public RiskLevel RiskLevel
        {
            get
            {
                var level = RiskLevel.Normal;
                if (Customer == null)
                    return level;
                if (Customer.IsHighRisk)
                    level = RiskLevel.Risky;
                if (StakeOverAverage(10))
                    level = RiskLevel.Unusual;
                if (StakeOverAverage(30))
                    level = RiskLevel.High;
                if (WinAmount >= 1000)
                    level = RiskLevel.High;

                return level;
            }
        }

        private bool StakeOverAverage(int timesOverAverage)
        {
            return Stake >(Customer.AverageStake * timesOverAverage);
        }
    }
}