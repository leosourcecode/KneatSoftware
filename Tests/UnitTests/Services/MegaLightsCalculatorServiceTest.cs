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

        [Fact(DisplayName = "Should calculate the stops by Week with success")]
        [Trait("MegaLights", "Calculate the stops")]
        public void ShouldCalculateStopsByWeekWithSuccess()
        {
            //Arrange
            double hoursbyWeek = 168;
            var distanceInMegaLights = 1000000;
            var megaLights = "80";
            var consumables = "1 week";
            double consumableValue = 1;
            var time = "week";
            _mocker.GetMock<ICosumablesService>().Setup(s => s.CalculateConsumableInHours(consumableValue, time)).Returns(hoursbyWeek * consumableValue);

            //Act
            var result = _megaLightsCalculatorService.CalculateStopsByDistance(distanceInMegaLights, megaLights, consumables);

            //Assert
            Assert.Equal(74, result);
        }

        [Fact(DisplayName = "Should calculate the stops by Day with success")]
        [Trait("MegaLights", "Calculate the stops")]
        public void ShouldCalculateStopsByDayWithSuccess()
        {
            //Arrange
            double hoursbyDay = 24;
            var distanceInMegaLights = 1000000;
            var megaLights = "100";
            var consumables = "5 days";
            double consumableValue = 5;
            var time = "days";
            _mocker.GetMock<ICosumablesService>().Setup(s => s.CalculateConsumableInHours(consumableValue, time)).Returns(hoursbyDay * consumableValue);

            //Act
            var result = _megaLightsCalculatorService.CalculateStopsByDistance(distanceInMegaLights, megaLights, consumables);

            //Assert
            Assert.Equal(83, result);
        }
    }
}
