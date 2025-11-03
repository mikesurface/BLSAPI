using CPIService.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlsAuthController : BlsControllerBase
    {
        #region Constructor

        public BlsAuthController(BlsDataService blsService) : base(blsService)
        {
        }

        #endregion

        [Authorize]
        [HttpGet("{seriesId}/{year}/{month}")]
        public async Task<IActionResult> GetValue(string seriesId, string year, string month)
        {
            return await GetValueForSeriesYearMonth(seriesId, year, month);
        }
    }
}
