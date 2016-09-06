using System.Text.RegularExpressions;

using Galaxy.Core.Models;
using Galaxy.Core.Utils;

namespace Galaxy.Core.Factories
{
    /// <summary>
    /// Factory to create units
    /// </summary>
    public class UnitFactory : FactoryBase<Unit>
    {
        public UnitFactory(string pattern) : base(pattern)
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
        public override Unit Create(string input)
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
            var symbolString = match.Groups[2].Value.Trim();
            Symbol symbol = SymbolUtil.ParseSymbol(symbolString);
            
            return symbol != Symbol.Unknown
                ? new Unit(units, symbol)
                : null;
        }
    }
}