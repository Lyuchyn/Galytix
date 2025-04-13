using GalytixAssessment.Models;

namespace GalytixAssessment.Repositories
{
    /// <summary>
    /// Database repository interface for GWP data.
    /// </summary>
    public interface IGwpDataRepository
    {
        /// <summary>
        /// Gets the GWPs by line of business for a given country.
        /// </summary>
        /// <param name="country"></param>
        /// <param name="lineOfBusiness"></param>
        /// <returns>List of GWP records or empty list.</returns>
        Task<List<GwpByCountry>> GetGwpByCountryAndLob(string country, string[] lineOfBusiness);
    }
}
