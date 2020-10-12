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
    }
}
