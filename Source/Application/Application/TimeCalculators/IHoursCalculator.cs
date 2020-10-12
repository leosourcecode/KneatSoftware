namespace Application.Services
{
    /// <summary>
    /// Implements the concrete classes: HoursByDay, HoursByWeek, HoursByMonth, HoursByYear
    /// </summary>
    public interface IHoursCalculator
    {
        /// <summary>
        /// Calculate the hours
        /// </summary>
        /// <returns>Hours</returns>
        double CalculateHours();
    }
}
