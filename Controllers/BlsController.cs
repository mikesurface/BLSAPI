using CPIService.Core;
using Microsoft.AspNetCore.Mvc;

namespace CPIService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BlsController : BlsControllerBase
    {
        #region Constructor

        public BlsController(BlsDataService blsService) : base(blsService) 
        {
        }

        #endregion

        [HttpGet("{seriesId}/{year}/{month}")]
        public async Task<IActionResult> GetValue(string seriesId, string year, string month)
        {
            return await GetValueForSeriesYearMonth(seriesId, year, month);
        }

    }
}
