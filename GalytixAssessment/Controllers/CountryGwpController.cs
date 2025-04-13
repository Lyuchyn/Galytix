using GalytixAssessment.Dtos;
using GalytixAssessment.Services;
using Microsoft.AspNetCore.Mvc;

namespace GalytixAssessment.Controllers
{
    [ApiController]
    [Route("api/gwp")]
    public class CountryGwpController(IGwpCalculationService gwpCalculationService) : ControllerBase
    {
        /// <summary>
        /// Calculates the average GWP for each line of business (LOB) in the specified country.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost("avg")]
        [ProducesResponseType(typeof(GwpOutputDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<GwpOutputDto>> CalculateAverageGwp(GwpInputDto dto)
        {
            var calcResult = await gwpCalculationService.CalculateAverageGwpByLob(dto);

            if (calcResult is null)
            {
                return NotFound("No GWP data found for the specified country and LOBs.");
            }

            return Ok(calcResult);
        }
    }
}
