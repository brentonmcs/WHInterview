using System.Collections.Generic;
using System.Linq;
using WH.Data;
using WH.Domain;

namespace WH.Business.Services
{
    public class BetImporter
    {
        private readonly CsvImporter _csvImporter;
        private readonly string _appDataPath;

        public BetImporter(CsvImporter csvImporter, string appDataPath)
        {
            _csvImporter = csvImporter;
            _appDataPath = appDataPath;
        }

        private List<CustomerBet> _resultedBets;
        public List<CustomerBet> ResultedBets
        {
            get { return _resultedBets ?? (_resultedBets = ReadResultedBets()); }
        }

        private List<CustomerBet> ReadResultedBets()
        {
            return _csvImporter.ReadFile(_appDataPath + "Settled.csv").ToList();
        }
    }
}
