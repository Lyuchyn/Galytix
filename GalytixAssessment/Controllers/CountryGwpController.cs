using GalytixAssessment.Dtos;
using GalytixAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace GalytixAssessment.Controllers
{
    [ApiController]
    [Route("api/gwp")]
    public class CountryGwpController(IGwpCalculationService gwpCalculationService) : ControllerBase
    {
        /// <summary>
        /// Gets the GWP data for a specific country.
        /// </summary>
        /// <param name="country">The country code.</param>
        /// <returns>A list of GWP data for the specified country.</returns>
        /// <response code="200">Returns the GWP data for the specified country and lines of business.</response>
        /// <response code="404">If no GWP is found for the given input.</response>
        [HttpPost("avg")]
        [ProducesResponseType(typeof(GwpOutputDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GwpOutputDto>> CalculateAverageGwp([FromBody] GwpInputDto dto, [FromServices] IValidator<GwpInputDto> validator)
        {
            var validationResult = await validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return ValidationProblem(new ValidationProblemDetails(validationResult.ToDictionary()));
            }

            var calcResult = await gwpCalculationService.CalculateAverageGwpByLob(dto);

            if (calcResult is null)
            {
                return NotFound("No GWP data found for the specified country and LOBs.");
            }

            return Ok(calcResult);
        }
    }
}
