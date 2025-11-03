using CPIService.Core;
using Microsoft.AspNetCore.Mvc;

namespace CPIService.Controllers
{
    public class BlsControllerBase : ControllerBase
    {
        #region Constructor and Globals

        private readonly BlsDataService _blsService;

        public BlsControllerBase(BlsDataService blsService)
        {
            _blsService = blsService;
        }

        #endregion

        protected async Task<IActionResult> GetValueForSeriesYearMonth(string seriesId, string year, string month)
        {
            // perform validation on our input
            var validationErrors = new List<string>();
            if (!BlsValidator.IsValidSeriesId(seriesId))
            {
                validationErrors.Add("Invalid series ID format.");
            }

            if (!DateValidator.IsValidYear(year))
                validationErrors.Add("Invalid year. Must be a 4-digit number between 1900 and the current year.");

            if (!DateValidator.IsValidMonth(month))
                validationErrors.Add("Invalid month. Must be a full month name like 'January'.");

            if (validationErrors.Count > 0)
            {
                return BadRequest(new
                {
                    Message = "Validation Errors",
                    Errors = validationErrors
                });
            }

            // input valid, now continue to process the request
            var data = await _blsService.GetBlsDataAsync(seriesId);
            var series = data.Results?.Series?.FirstOrDefault();

            var match = series?.Data?.FirstOrDefault(d =>
                d.Year == year && d.PeriodName.Equals(month, StringComparison.OrdinalIgnoreCase));

            if (match == null) return NotFound();

            return Ok(new
            {
                match.ValueAsInt,
                match.Notes
            });
        }
    }
}
