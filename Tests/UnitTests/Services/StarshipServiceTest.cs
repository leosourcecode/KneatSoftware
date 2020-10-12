using Infrastructure.Services;
using Xunit;
using Moq.AutoMock;
using Application.Services;
using System.Threading.Tasks;
using Application.Helpers;
using Moq;
using System;
using System.IO;
using Application.Builders;
using System.Linq;
using Newtonsoft.Json;
using Contracts.Domain;

namespace UnitTests.Services
{
    public class StarshipServiceTest
    {
        private readonly AutoMocker _mocker;
        private readonly IStarshipService _starshipService;
        private readonly Mock<IHttpClient> _httpClient;
        private readonly Mock<IKneatSoftwareUrlBuilder> _kneatSoftwareUrlBuilder;
        private readonly Mock<IMegaLightsCalculatorService> _megaLightsCalculatorService;

        public StarshipServiceTest()
        {
            _mocker = new AutoMocker();
            _starshipService = _mocker.CreateInstance<StarshipService>();
            _httpClient = _mocker.GetMock<IHttpClient>();
            _kneatSoftwareUrlBuilder = _mocker.GetMock<IKneatSoftwareUrlBuilder>();
            _megaLightsCalculatorService = _mocker.GetMock<IMegaLightsCalculatorService>();
        }

        [Fact(DisplayName = "Should get the Starships")]
        [Trait("Starships", "Get the Starships with the stops calculation")]
        public async Task ShouldCalculateStopsByMonthWithSuccess()
        {
            //Arrange
            double distance = 1000000;
            var url = "http://swapi.dev/api/starships/";        
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SampleFiles\StarWarsApiResponse.json");
            var json = File.ReadAllText(filePath);
            var apiResponse = JsonConvert.DeserializeObject<StarWarsApiResponse>(json);

            _kneatSoftwareUrlBuilder.Setup(s => s.GetAllStarshipsApiUrl()).Returns(url);
            _httpClient.Setup(s => s.GetAsync(url)).ReturnsAsync(json);
            _megaLightsCalculatorService.Setup(s => s.CalculateStopsByDistance(distance, apiResponse.Results[0].MGLT, apiResponse.Results[0].Consumables)).Returns(74);

            //Act
            var starships = (await _starshipService.GetAllStarshipsAsync(distance)).ToList();

            //Assert
            Assert.Single(starships);
            Assert.Equal(74, starships[0].Stops);
            Assert.Equal(apiResponse.Results[0].Consumables, starships[0].Consumables);
            Assert.Equal(apiResponse.Results[0].Manufacturer, starships[0].Manufacturer);
            Assert.Equal(apiResponse.Results[0].MGLT, starships[0].MGLT);
            Assert.Equal(apiResponse.Results[0].Model, starships[0].Model);
            Assert.Equal(apiResponse.Results[0].Name, starships[0].Name);
        }
    }
}
