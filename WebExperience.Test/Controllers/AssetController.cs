using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebExperience.Test.Models;
using WebExperience.Test.Repository;
using WebExperience.Test.Services;

namespace WebExperience.Test.Controllers
{
    public class AssetController : ApiController
    {
        private readonly IAssetService _assetService;
        // TODO
        // Create an API controller via REST to perform all CRUD operations on the asset objects created as part of the CSV processing test
        // Visualize the assets in a paged overview showing the title and created on field
        // Clicking an asset should navigate the user to a detail page showing all properties
        // Any data repository is permitted
        // Use a client MVVM framework

        public AssetController() : this(new AssetService(new AssetRepository()))
        {

        }

        public AssetController(IAssetService assetService) { 
                _assetService = assetService;
        }
        [Route("api/asset/asset-list")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Asset>))]
        public async Task<IHttpActionResult> GetAssetList() {
            return Ok(await _assetService.GetAssetList());
        }

        [Route("api/asset/asset-details/{Id}")]
        [HttpGet]
        [ResponseType(typeof(Asset))]
        public async Task<IHttpActionResult> GetAssetDetailsById(string Id)
        {
            return Ok(await _assetService.GetAssetDetailsById(Id));
        }
    }
}
