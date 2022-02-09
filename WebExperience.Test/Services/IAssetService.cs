using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExperience.Test.Models;

namespace WebExperience.Test.Services
{
    public interface IAssetService
    {
        Task<List<Asset>> GetAssetList();
        Task<Asset> GetAssetDetailsById(string id);
    }
}
