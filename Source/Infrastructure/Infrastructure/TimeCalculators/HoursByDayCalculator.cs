using Application.Services;
using Application.TimeCalculators;

namespace Infrastructure.TimeCalculation
{
    public class HoursByDayCalculator : IHoursCalculator
    {
        private readonly IHours _hours;

        public HoursByDayCalculator(IHours hours)
        {
            _hours = hours;
        }

        /// <summary>
        /// Calculate the hours, defining the parameter 1 = 1 day
        /// </summary>
        /// <returns>hours</returns>
        public double CalculateHours()
        {
            return _hours.Get(1);
        }
    }
}
