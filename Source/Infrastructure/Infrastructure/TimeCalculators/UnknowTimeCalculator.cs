using Application.Services;
using Application.TimeCalculators;

namespace Infrastructure.TimeCalculation
{
    public class UnknowTimeCalculator : IHoursCalculator
    {
        private readonly IHours _hours;

        public UnknowTimeCalculator(IHours hours)
        {
            _hours = hours;
        }

        /// <summary>
        /// Calculate the hours, defining the parameter 0 (Unknow).
        /// </summary>
        /// <returns>hours</returns>
        public double CalculateHours()
        {
            return _hours.Get(0);
        }
    }
}
