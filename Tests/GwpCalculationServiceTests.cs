using GalytixAssessment.Dtos;
using GalytixAssessment.Models;
using GalytixAssessment.Repositories;
using GalytixAssessment.Services;
using Moq;

namespace Tests
{
    public class GwpCalculationServiceTests
    {
        private readonly Mock<IGwpDataRepository> _gwpDataRepositoryMock = new();
        private readonly GwpCalculationService _underTest;

        public GwpCalculationServiceTests()
        {
            _underTest = new GwpCalculationService(_gwpDataRepositoryMock.Object);
        }

        [Fact]
        public async Task CalculateAverageGwpByLob_ReturnsNull_WhenNoDataFound()
        {
            // Arrange
            var gwpInputDto = new GwpInputDto { Country = "USA", Lob = ["Lob1"] };
            _gwpDataRepositoryMock.Setup(repo => repo.GetGwpByCountryAndLob(gwpInputDto.Country, gwpInputDto.Lob))
                .ReturnsAsync([]);

            // Act
            var result = await _underTest.CalculateAverageGwpByLob(gwpInputDto);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CalculateAverageGwpByLob_ReturnsCorrectData_WhenDataFound()
        {
            // Arrange
            var gwpInputDto = new GwpInputDto { Country = "USA", Lob = ["Lob1", "Lob2"] };
            var gwpData = new List<GwpByCountry>
            {
                new() { LineOfBusiness = "Lob1", Y2008 = 100, Y2009 = 200, Y2010 = 300, Y2011 = 400, Y2012 = 500, Y2013 = 600, Y2014 = 700, Y2015 = 800 },
                new() { LineOfBusiness = "Lob2", Y2009 = 200, Y2010 = 300, Y2015 = 800 }
            };
            _gwpDataRepositoryMock.Setup(repo => repo.GetGwpByCountryAndLob(gwpInputDto.Country, gwpInputDto.Lob))
                .ReturnsAsync(gwpData);

            // Act
            var result = await _underTest.CalculateAverageGwpByLob(gwpInputDto);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Lob1", result.AvrgGwpByLob.Keys);
            Assert.Equal(450, result.AvrgGwpByLob["Lob1"]);
            Assert.Contains("Lob2", result.AvrgGwpByLob.Keys);
            Assert.Equal(162.5, result.AvrgGwpByLob["Lob2"]);
        }
    }
}
