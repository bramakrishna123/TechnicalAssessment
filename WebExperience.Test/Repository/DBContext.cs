using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebExperience.Test.Models;

namespace WebExperience.Test.Repository
{
    public class DBContext
    {
        public List<Asset> AssetList { set; get; }
        //public readonly DBContext _dbContext = null;
        public DBContext()
        {
            //_dbContext = new DBContext() {
            AssetList = GetAssetDataFromCsv();
        //};
        }
        private List<Asset> GetAssetDataFromCsv() {
            List<Asset> lstRecords = new List<Asset>();
            string csvFile = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data")+"/AssetImport.csv");
            string[] data = csvFile.Split('\n');
            string[] headers = data[0].Split(',');
            string[] records = data.Skip(1).ToArray();
            foreach (string value in records)
            {
                //if (!string.IsNullOrEmpty(value))
                {
                    string[] values = value.Split(',');
                    if (!string.IsNullOrEmpty(values[0].Trim()))
                    {
                        Asset r = new Asset()
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
            }
            return lstRecords;
        }
    }
}