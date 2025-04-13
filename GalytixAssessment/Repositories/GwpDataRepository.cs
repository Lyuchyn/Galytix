using GalytixAssessment.Models;

namespace GalytixAssessment.Repositories
{
    public class GwpDataRepository(GwpByCountryDataSet gwpByCountryDataSet) : IGwpDataRepository
    {
        public Task<List<GwpByCountry>> GetGwpByCountryAndLob(string country, string[] lineOfBusiness)
        {
            if (string.IsNullOrWhiteSpace(country))
            {
                throw new ArgumentException($"'{nameof(country)}' cannot be null or whitespace.", nameof(country));
            }

            if (lineOfBusiness is null)
            {
                throw new ArgumentNullException(nameof(lineOfBusiness));
            }

            var data = gwpByCountryDataSet.GwpRecords
                .Where(x => country.Equals(x.Country, StringComparison.OrdinalIgnoreCase))
                .Where(x => lineOfBusiness.Contains(x.LineOfBusiness))
                .ToList();

            return Task.FromResult(data);
        }
    }
}
