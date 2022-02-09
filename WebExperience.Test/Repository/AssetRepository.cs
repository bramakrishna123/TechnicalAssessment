using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebExperience.Test.Models;

namespace WebExperience.Test.Repository
{
    public class AssetRepository : DBContext, IAssetRepository
    {
        public AssetRepository()
        {

        }

        public async Task<List<Asset>> GetAssetList() { 
            return AssetList.Take(100).ToList<Asset>();
        }

        public async Task<Asset> GetAssetDetailById(string id)
        {
            return await Task.FromResult(AssetList.Where(x=>x.AssetId == id).FirstOrDefault());
        }
    }
}