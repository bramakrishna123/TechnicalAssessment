using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExperience.Test.Models;

namespace WebExperience.Test.Repository
{
    public interface IAssetRepository
    {
        Task<List<Asset>> GetAssetList();
        Task<Asset> GetAssetDetailById(string id);
    }
}
