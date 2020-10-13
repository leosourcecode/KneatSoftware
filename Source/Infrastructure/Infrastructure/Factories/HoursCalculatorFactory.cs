using Application.Services;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Factories
{
    public class HoursCalculatorFactory
    {
        private readonly IEnumerable<IHoursCalculator> _hoursCalculation;

        public HoursCalculatorFactory(IEnumerable<IHoursCalculator> hoursCalculation)
        {
            _hoursCalculation = hoursCalculation;
        }

        /// <summary>
        /// Method responsible to get the specific time calculator
        /// </summary>
        /// <param name="timeName">Type of the time</param>
        /// <returns>IHoursCalculator</returns>
        public IHoursCalculator GetTimeCalculator(string timeName)
        {
            switch (timeName.ToLower())
            {
                case "day":
                case "days":
                    return _hoursCalculation.FirstOrDefault(c => c.GetType().Name.Equals("HoursByDayCalculator"));
                case "week":
                case "weeks":
                    return _hoursCalculation.FirstOrDefault(c => c.GetType().Name.Equals("HoursByWeekCalculator"));
                case "month":
                case "months":
                    return _hoursCalculation.FirstOrDefault(c => c.GetType().Name.Equals("HoursByMonthCalculator"));
                case "year":
                case "years":
                    return _hoursCalculation.FirstOrDefault(c => c.GetType().Name.Equals("HoursByYearCalculator"));
                default:
                    return _hoursCalculation.FirstOrDefault(c => c.GetType().Name.Equals("UnknowTimeCalculator"));
            }
        }
    }
}
