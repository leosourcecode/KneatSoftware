using Application.TimeCalculators;
using Infrastructure.TimeCalculators;
using Xunit;

namespace UnitTests.Services
{
    public class HoursTest
    {
        private IHours _hours;

        [Fact(DisplayName = "Should get the hours by 1 day")]
        [Trait("Hours", "Get the hours")]
        public void ShouldGetHoursFor1Day()
        {
            //Arrange
            _hours = new Hours();
            var days = 1;

            //Act
            var result = _hours.Get(days);

            //Assert
            Assert.Equal(24, result);
        }

        [Fact(DisplayName = "Should get the hours by 1 week")]
        [Trait("Hours", "Get the hours")]
        public void ShouldGetHoursFor1Week()
        {
            //Arrange
            _hours = new Hours();
            var days = 7;

            //Act
            var result = _hours.Get(days);

            //Assert
            Assert.Equal(168, result);
        }

        [Fact(DisplayName = "Should get the hours by 1 month")]
        [Trait("Hours", "Get the hours")]
        public void ShouldGetHoursFor1Month()
        {
            //Arrange
            _hours = new Hours();
            var days = 365;

            //Act
            var result = _hours.Get(days);

            //Assert
            Assert.Equal(730, (result / 12));
        }

        [Fact(DisplayName = "Should get the hours by 1 year")]
        [Trait("Hours", "Get the hours")]
        public void ShouldGetHoursFor1Year()
        {
            //Arrange
            _hours = new Hours();
            var days = 365;

            //Act
            var result = _hours.Get(days);

            //Assert
            Assert.Equal(8760, result);
        }
    }
}
