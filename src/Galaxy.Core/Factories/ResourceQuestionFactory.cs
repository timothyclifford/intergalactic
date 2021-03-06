using System.Text.RegularExpressions;

using Galaxy.Core.Models;

namespace Galaxy.Core.Factories
{
    /// <summary>
    /// Factory to create resource questions
    /// </summary>
    public class ResourceQuestionFactory : FactoryBase<ResourceQuestion>
    {
        public ResourceQuestionFactory(string pattern) : base(pattern)
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
        public override ResourceQuestion Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var match = Regex.Match(input, _pattern);
            if (!match.Success || match.Groups.Count != 3)
            {
                return null;
            }
            
            var units = match.Groups[1].Value.Trim();
            var resource = match.Groups[2].Value.Trim();

            return new ResourceQuestion(units, resource);
        }
    }
}