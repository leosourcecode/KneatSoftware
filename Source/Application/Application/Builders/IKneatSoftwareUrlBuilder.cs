namespace Application.Builders
{
    /// <summary>
    /// Builder to create StarWars API Url
    /// </summary>
    public interface IKneatSoftwareUrlBuilder
    {
        /// <summary>
        /// Build GetAllStarships URL to StarWars API
        /// </summary>
        /// <returns>A string with the URL</returns>
        string GetAllStarshipsApiUrl();
    }
}
