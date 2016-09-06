using System.Text.RegularExpressions;

using Galaxy.Core.Models;

namespace Galaxy.Core.Factories
{
    /// <summary>
    /// Factory to create resources
    /// </summary>
    public class ResourceFactory : FactoryBase<Resource>
    {
        public ResourceFactory(string pattern) : base(pattern)
        {
        }

        /// <summary>
        /// Creates object from string input
        /// </summary>
        /// <param name="input">
        /// The raw string input
        /// </param>
        /// <returns>
        /// The populated object
        /// </returns>
        public override Resource Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var match = Regex.Match(input, _pattern);
            if (!match.Success || match.Groups.Count != 4)
            {
                return null;
            }

            var units = match.Groups[1].Value.Trim();
            var resource = match.Groups[2].Value.Trim();
            var creditsString = match.Groups[3].Value.Trim();
            float credits;

            return float.TryParse(creditsString, out credits) 
                ? new Resource(resource, units, credits)
                : null;
        }
    }
}