using GalytixAssessment.Dtos;

namespace GalytixAssessment.Services
{
    public interface IGwpCalculationService
    {
        /// <summary>
        /// Calculates the average GWP for each line of business (LOB) in the specified country.
        /// </summary>
        /// <param name="gwpInputDto">The input data transfer object containing the country and LOBs.</param>
        /// <returns>Instance of <see cref="GwpOutputDto"/> class or null if no such GWP found.</returns>
        Task<GwpOutputDto?> CalculateAverageGwpByLob(GwpInputDto gwpInputDto);
    }
}
