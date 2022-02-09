using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public string Name { get { return "JSON Reading Test";  } }

        public void Run()
        {
            var jsonData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            PrintOverview(jsonData);
        }

        private void PrintOverview(byte[] data)
        {
            //var json = Convert.FromBase64String(data);
            var json = Encoding.UTF8.GetString(data,0,data.Length);
            var samplePoints = Newtonsoft.Json.JsonConvert.DeserializeObject<SamplePoints>(json);
            if (samplePoints!=null && samplePoints.Samples?.Count > 0) {
                Console.WriteLine("Parameter\t\tLow\tAVG\tMAX\t");
                Console.WriteLine("=========\t\t===\t===\t===\t");
                Console.WriteLine($"temperature\t\t{samplePoints.Samples.Min(x=>x.Temperature)}\t{Math.Round(samplePoints.Samples.Where(x=>x.Temperature>0).Average(x=>x.Temperature),2)}\t{samplePoints.Samples.Max(x => x.Temperature)}\t");
                Console.WriteLine($"pH\t\t\t{samplePoints.Samples.Min(x => x.Ph)}\t{Math.Round(samplePoints.Samples.Where(x => x.Ph > 0).Average(x => x.Ph), 2)}\t{samplePoints.Samples.Max(x => x.Ph)}\t");
                Console.WriteLine($"Chloride\t\t{samplePoints.Samples.Min(x => x.Chloride)}\t{Math.Round(samplePoints.Samples.Where(x => x.Chloride > 0).Average(x => x.Chloride), 2)}\t{samplePoints.Samples.Max(x => x.Chloride)}\t");
                Console.WriteLine($"Phosphate\t\t{samplePoints.Samples.Min(x => x.Phosphate)}\t{Math.Round(samplePoints.Samples.Where(x => x.Phosphate > 0).Average(x => x.Phosphate), 2)}\t{samplePoints.Samples.Max(x => x.Phosphate)}\t");
                Console.WriteLine($"Nitrate\t\t\t{samplePoints.Samples.Min(x => x.Nitrate)}\t{Math.Round(samplePoints.Samples.Where(x => x.Nitrate > 0).Average(x => x.Nitrate), 2)}\t{samplePoints.Samples.Max(x => x.Nitrate)}\t");
            }
        }
    }
    public class SamplePoints { 
        public List<Parameter> Samples { get; set; }
    }
    public class Parameter {
        public DateTime Date { get; set; }
        public decimal Temperature { get; set; }
        public int Ph { get; set; }
        public int Phosphate { get; set; }
        public int Chloride { get; set; }
        public int Nitrate { get; set; }
    }
}
