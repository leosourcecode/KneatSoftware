using Application.Services;
using Infrastructure.TimeCalculation;
using Infrastructure.TimeCalculators;
using Xunit;

namespace UnitTests.Services
{
    public class HoursCalculatorTest
    {
        private IHoursCalculator _hoursCalculator;

        [Fact(DisplayName = "Should calculate the hours by year")]
        [Trait("Hours", "Calculate the hours")]
        public void ShouldGetHoursPerYear()
        {
            //Arrange
            _hoursCalculator = new HoursByYearCalculator(new Hours());

            //Act
            var result = _hoursCalculator.CalculateHours();

            //Assert
            Assert.Equal(8760, result);
        }

        [Fact(DisplayName = "Shouldn't get the hours by year")]
        [Trait("Hours", "Calculate the hours")]
        public void ShouldNotGetHours()
        {
            //Arrange
            _hoursCalculator = new UnknowTimeCalculator(new Hours());

            //Act
            var result = _hoursCalculator.CalculateHours();

            //Assert
            Assert.Equal(0, result);
        }

        [Fact(DisplayName = "Should calculate the hours by day")]
        [Trait("Hours", "Calculate the hours")]
        public void ShouldGetHoursPerDay()
        {
            //Arrange
            _hoursCalculator = new HoursByDayCalculator(new Hours());

            //Act
            var result = _hoursCalculator.CalculateHours();

            //Assert
            Assert.Equal(24, result);
        }

        [Fact(DisplayName = "Should calculate the hours by week")]
        [Trait("Hours", "Calculate the hours")]
        public void ShouldGetHoursPerWeek()
        {
            //Arrange
            _hoursCalculator = new HoursByWeekCalculator(new Hours());

            //Act
            var result = _hoursCalculator.CalculateHours();

            //Assert
            Assert.Equal(168, result);
        }

        [Fact(DisplayName = "Should calculate the hours by month")]
        [Trait("Hours", "Calculate the hours")]
        public void ShouldGetHoursPerMonth()
        {
            //Arrange
            _hoursCalculator = new HoursByMonthCalculator(new Hours());

            //Act
            var result = _hoursCalculator.CalculateHours();

            //Assert
            Assert.Equal(730, result);
        }
    }
}
