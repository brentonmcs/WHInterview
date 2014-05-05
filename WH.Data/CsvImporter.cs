using System;
using System.Collections.Generic;
using System.IO;
using WH.Domain;

namespace WH.Data
{
    public class CsvImporter
    {
        public IEnumerable<CustomerBet> ReadFile(string fileName)
        {
            var result = new List<CustomerBet>();

            var first = true;
            using (var streamReader = new StreamReader(File.OpenRead(fileName)))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var betRow = line.Split(',');

                    if (first)
                    {
                        first = false;
                        continue;                        
                    }
                    result.Add(new CustomerBet
                    {
                        Customer = Convert.ToInt32(betRow[0]),
                        Event = Convert.ToInt32(betRow[1]),
                        Participant = Convert.ToInt32(betRow[2]),
                        Stake = Convert.ToInt32(betRow[3]),
                        Win = Convert.ToInt32(betRow[4])
                    });
                }
                return result;
            }
        }
    }
}
