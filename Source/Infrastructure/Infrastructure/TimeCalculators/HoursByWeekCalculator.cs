using Application.Services;
using Application.TimeCalculators;

namespace Infrastructure.TimeCalculation
{
    public class HoursByWeekCalculator : IHoursCalculator
    {
        private readonly IHours _hours;

        public HoursByWeekCalculator(IHours hours)
        {
            _hours = hours;
        }

        /// <summary>
        /// Calculate the hours, defining the parameter 7 days = 1 week.
        /// </summary>
        /// <returns>hours</returns>
        public double CalculateHours()
        {
            return _hours.Get(7);
        }
    }
}
