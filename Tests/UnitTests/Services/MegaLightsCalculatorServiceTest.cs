using Infrastructure.Services;
using Xunit;
using Moq.AutoMock;
using Application.Services;

namespace UnitTests.Services
{
    public class MegaLightsCalculatorServiceTest
    {
        private readonly AutoMocker _mocker;
        private readonly MegaLightsCalculatorService _megaLightsCalculatorService;

        public MegaLightsCalculatorServiceTest()
        {
            _mocker = new AutoMocker();
            _megaLightsCalculatorService = _mocker.CreateInstance<MegaLightsCalculatorService>();
        }

        [Fact(DisplayName = "Should calculate the stops by Month with success")]
        [Trait("MegaLights", "Calculate the stops")]
        public void ShouldCalculateStopsByMonthWithSuccess()
        {
            //Arrange
            double hoursbyMonth = 730;
            var distanceInMegaLights = 1000000;
            var megaLights = "75";
            var consumables = "2 months";
            double consumableValue = 2;
            var time = "months";
            _mocker.GetMock<ICosumablesService>().Setup(s => s.CalculateConsumableInHours(consumableValue, time)).Returns(hoursbyMonth * consumableValue);

            //Act
            var result = _megaLightsCalculatorService.CalculateStopsByDistance(distanceInMegaLights, megaLights, consumables);

            //Assert
            Assert.Equal(9, result);
        }
    }
}
