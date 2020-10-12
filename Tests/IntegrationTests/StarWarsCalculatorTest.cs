using Application.Services;
using IntegrationTests.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    [Collection(nameof(IntegrationTestConfigurationCollection))]
    public class StarWarsCalculatorTest
    {
        private readonly IntegrationTestConfiguration _integrationTestConfiguration;
        private readonly IStarshipService _starshipService;

        public StarWarsCalculatorTest(IntegrationTestConfiguration integrationTestConfiguration)
        {
            _integrationTestConfiguration = integrationTestConfiguration;
            _starshipService = _integrationTestConfiguration._starshipService;
        }

        [Fact(DisplayName = "Get the starships with the stops")]
        [Trait("Starships", "Should Get the starships with the stops calculated")]
        public async Task ShouldGetStarshipsWithStopsCalculated()
        {
            //Arrange
            double distanceInMegaLights = _integrationTestConfiguration.GetDistanceInMegaLights();

            //Act
            var starships = (await _starshipService.GetAllStarshipsAsync(distanceInMegaLights)).ToList();

            //Assert
            Assert.True(starships.Count > 0);
            Assert.True(starships.Select(s => s.Name == "Y-wing" && s.Stops == 74).Count() > 0);
            Assert.True(starships.Select(s => s.Name == "Millennium Falcon" && s.Stops == 9).Count() > 0);
            Assert.True(starships.Select(s => s.Name == "Rebel Transport" && s.Stops == 11).Count() > 0);
        }
    }
}
