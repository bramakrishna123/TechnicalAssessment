using System.Collections.Generic;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted

            var csvFile = Resources.AssetImport;
            string[] data = csvFile.Split('\n');
            var result = GetCSVRecords(data);
        }

        private List<Record> GetCSVRecords(string[] data) {
            List<Record> lstRecords = new List<Record>();
            string[] headers = data[0].Split(',');
            string[] records = data.Skip(1).ToArray();
            foreach (string value in records) {
                if (!string.IsNullOrEmpty(value))
                {
                    string[] values = value.Split(',');
                    Record r = new Record()
                    {
                        AssetId = values[0],
                        FileName = values[1],
                        MimeType = values[2],
                        CreatedBy = values[3],
                        Email = values[4],
                        Country = values[5],
                        Description = values[6]
                    };
                    lstRecords.Add(r);
                }
            }
            return lstRecords;
        }
    }

    public class Record {
        public string AssetId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
    }
}
