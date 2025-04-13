using GalytixAssessment.Models;
using GalytixAssessment.Repositories;
using Moq;

namespace Tests
{
    public class GwpDataRepositoryTests
    {
        private readonly Mock<IGwpByCountryDataSet> _mockGwpByCountryDataSet = new();
        private readonly GwpDataRepository underTest;

        public GwpDataRepositoryTests()
        {
            underTest = new GwpDataRepository(_mockGwpByCountryDataSet.Object);
        }

        [Fact]
        public async Task GetGwpByCountryAndLob_ShouldReturnData_WhenCountryAndLobAreValid()
        {
            // Arrange
            var country = "USA";
            var lineOfBusiness = new[] { "Lob1", "Lob2" };
            var expectedData = new List<GwpByCountry>
            {
                new GwpByCountry { Country = "USA", LineOfBusiness = "Lob1" },
                new GwpByCountry { Country = "USA", LineOfBusiness = "Lob2" }
            };

            _mockGwpByCountryDataSet.Setup(x => x.GwpRecords).Returns(expectedData);

            // Act
            var result = await underTest.GetGwpByCountryAndLob(country, lineOfBusiness);

            // Assert
            Assert.Equal(expectedData, result);
        }

        [Fact]
        public async Task GetGwpByCountryAndLob_ShouldThrowArgumentException_WhenCountryIsNullOrWhitespace()
        {
            // Arrange
            var lineOfBusiness = new[] { "Lob1", "Lob2" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => underTest.GetGwpByCountryAndLob(null, lineOfBusiness));
            await Assert.ThrowsAsync<ArgumentException>(() => underTest.GetGwpByCountryAndLob(" ", lineOfBusiness));
        }

        [Fact]
        public async Task GetGwpByCountryAndLob_ShouldThrowArgumentNullException_WhenLineOfBusinessIsNull()
        {
            // Arrange
            var country = "USA";

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => underTest.GetGwpByCountryAndLob(country, null));
        }

        [Fact]
        public async Task GetGwpByCountryAndLob_ShouldReturnEmptyList_WhenNoMatchingRecords()
        {
            // Arrange
            var country = "USA";
            var lineOfBusiness = new[] { "Lob1", "Lob2" };
            var data = new List<GwpByCountry>
            {
                new GwpByCountry { Country = "Canada", LineOfBusiness = "Lob3" }
            };

            _mockGwpByCountryDataSet.Setup(x => x.GwpRecords).Returns(data);

            // Act
            var result = await underTest.GetGwpByCountryAndLob(country, lineOfBusiness);

            // Assert
            Assert.Empty(result);
        }
    }
}
