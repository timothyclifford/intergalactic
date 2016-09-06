using System.Text.RegularExpressions;

using Galaxy.Core.Models;

namespace Galaxy.Core.Factories
{
    /// <summary>
    /// Factory to create unit questions
    /// </summary>
    public class UnitQuestionFactory : FactoryBase<UnitQuestion>
    {
        public UnitQuestionFactory(string pattern) : base(pattern)
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
        public override UnitQuestion Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var match = Regex.Match(input, _pattern);
            if (!match.Success || match.Groups.Count != 2)
            {
                return null;
            }

            var units = match.Groups[1].Value.Trim();

            return new UnitQuestion(units);
        }
    }
}