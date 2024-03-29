﻿using System.Collections.Generic;
using WH.Domain;

namespace WH.Interview.Models
{
    public class RiskViewModel
    {
        public List<Customer> HighRiskCustomers { get; set; }

        public List<Bet> HighRiskUpCommingBets { get; set; }
        public List<Customer> AllCustomers { get; set; }
        public List<Bet> AllBets { get; set; }
    }
}