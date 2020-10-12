using System.ComponentModel.DataAnnotations;

namespace Infrastructure.ExtensionMethods
{
    /// <summary>
    /// Distance Helper
    /// </summary>
    public static class MegaLightsHelper
    {
        /// <summary>
        /// Get value MegaLights from string
        /// </summary>
        /// <param name="value">String that contains the value in MegaLights</param>
        /// <returns>MegaLights</returns>
        public static double GetMegaLightsFromString(this string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ValidationException("MegaLights cannot be null or empty!");

            double.TryParse(value, out double mglt);

            if (mglt > 0) return mglt;
            throw new ValidationException($"Invalid value to convert to MegaLights! Value: {value}");
        }

        /// <summary>
        /// Check if the value MegaLights from string is valid
        /// </summary>
        /// <param name="value">String that contains the value in MegaLights</param>
        /// <returns>bool</returns>
        public static bool IsValidValue(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            double.TryParse(value, out double mglt);

            if (mglt > 0) return true;
            return false;
        }
    }
}
