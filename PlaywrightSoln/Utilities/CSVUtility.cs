using CsvHelper;
using PlaywrightSoln.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightSoln.Utilities
{
    public static class CSVUtility
    {
        public static IEnumerable<T> ReadCSV<T>(string fileName)
        {
            string path = HandleContent.GetFilePath(fileName+".csv");
            IEnumerable<T> records = null;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<T>().ToList();
            }
            return records;
        }
    }
}
