using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebExperience.Test.Models;
using WebExperience.Test.Repository;

namespace WebExperience.Test.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
       
        public AssetService(IAssetRepository assetRepository) {
            _assetRepository = assetRepository;
        }
        public async Task<List<Asset>> GetAssetList()
        {
            return await _assetRepository.GetAssetList();
        }

        public async Task<Asset> GetAssetDetailsById(string id)
        {
            return await _assetRepository.GetAssetDetailById(id);
        }
    }
}