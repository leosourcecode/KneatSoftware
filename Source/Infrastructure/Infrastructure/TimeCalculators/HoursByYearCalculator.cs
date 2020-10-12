using Application.Services;
using Application.TimeCalculators;

namespace Infrastructure.TimeCalculation
{
    public class HoursByYearCalculator : IHoursCalculator
    {
        private readonly IHours _hours;

        public HoursByYearCalculator(IHours hours)
        {
            _hours = hours;
        }

        /// <summary>
        /// Calculate the hours, defining the parameter 365 days = 1 year.
        /// </summary>
        /// <returns>hours</returns>
        public double CalculateHours()
        {
            return _hours.Get(365) ;
        }
    }
}
