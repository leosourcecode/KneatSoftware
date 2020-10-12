using Application.Builders;
using Core;
using System.IO;

namespace Infrastructure.Builders
{
    public class KneatSoftwareUrlBuilder : IKneatSoftwareUrlBuilder
    {
        /// <summary>
        /// Build GetAllStarships URL to swapi
        /// </summary>
        /// <returns>A string with the URL</returns>
        public string GetAllStarshipsApiUrl() => GetPath(KneatSoftwareConfiguration.StarWarsBaseUrl, KneatSoftwareConfiguration.StarWarsGetStarshipsApiUrl);

        private static string GetPath(params string[] segments) => Path.Combine(segments);
    }
}
