using System.Collections.Generic;
using System.Linq;
using WH.Data.Utilities;
using WH.Domain;

namespace WH.Data
{
    public class BetData
    {
        private readonly CsvImporter _csvImporter;
        private readonly string _appDataPath;

        public BetData(CsvImporter csvImporter, string appDataPath)
        {
            _csvImporter = csvImporter;
            _appDataPath = appDataPath;
        }

        private List<CustomerBet> _resultedBets;
        public virtual List<CustomerBet> ResultedBets
        {
            get { return _resultedBets ?? (_resultedBets = ReadResultedBets()); }
        }

        private List<CustomerBet> ReadResultedBets()
        {
            return _csvImporter.ReadFile(_appDataPath + "Settled.csv").ToList();
        }
    }
}
