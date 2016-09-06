using System;

using Galaxy.Core.Models;

namespace Galaxy.Core.Utils
{
    /// <summary>
    /// Utility class for working with symbols
    /// </summary>
    public class SymbolUtil
    {
        /// <summary>
        /// Parses a string representation of a symbol to the enum
        /// </summary>
        /// <param name="value">
        /// The raw string value
        /// </param>
        /// <returns>
        /// A symbol enum
        /// </returns>
        public static Symbol ParseSymbol(string value)
        {
            Symbol symbol;
            return Enum.TryParse(value, out symbol)
                ? symbol
                : Symbol.Unknown;
        }
    }
}