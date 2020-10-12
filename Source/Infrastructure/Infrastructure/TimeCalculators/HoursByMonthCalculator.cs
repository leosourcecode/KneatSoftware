using Application.Services;
using Application.TimeCalculators;

namespace Infrastructure.TimeCalculation
{
    public class HoursByMonthCalculator : IHoursCalculator
    {
        private readonly IHours _hours;

        public HoursByMonthCalculator(IHours hours)
        {
            _hours = hours;
        }

        /// <summary>
        /// Calculate the hours, getting an average of 365 days divided by 12 months.
        /// </summary>
        /// <returns>hours</returns>
        public double CalculateHours()
        {
            return (_hours.Get(365) / 12);
        }
    }
}
