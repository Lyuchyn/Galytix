using GalytixAssessment.Dtos;
using GalytixAssessment.Repositories;

namespace GalytixAssessment.Services
{
    public class GwpCalculationService(IGwpDataRepository gwpDataRepository) : IGwpCalculationService
    {
        public async Task<GwpOutputDto?> CalculateAverageGwpByLob(GwpInputDto gwpInputDto)
        {
            var data = await gwpDataRepository.GetGwpByCountryAndLob(gwpInputDto.Country, gwpInputDto.Lob);
            if (data.Count == 0)
            {
                return null;
            }

            var averageGwpByLob = data
                .ToDictionary(
                    g => g.LineOfBusiness,
                    g => g.GetAvgGwpFrom2008To2015()
                );

            return new GwpOutputDto
            {
                AvrgGwpByLob = averageGwpByLob
            };
        }
    }
}
