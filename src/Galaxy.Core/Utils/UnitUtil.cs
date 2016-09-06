using System;
using System.Collections.Generic;
using System.Linq;

using Galaxy.Core.Models;

namespace Galaxy.Core.Utils
{
    /// <summary>
    /// Utility class for working with units
    /// </summary>
    public class UnitUtil
    {
        /// <summary>
        /// Matches unit names string to definitions 
        /// </summary>
        /// <param name="names">
        /// The unit names as a string
        /// </param>
        /// <param name="definitions">
        /// The list of unit definitions
        /// </param>
        /// <returns>
        /// A list of units matching the names supplied
        /// </returns>
        public static IEnumerable<Unit> GetByNames(string names, IEnumerable<Unit> definitions)
        {
            foreach (var name in StringUtil.SplitBySpaces(names))
            {
                var unit = definitions.FirstOrDefault(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (unit == null)
                {
                    throw new ArgumentException($"No definition provided for unit {name}");
                }

                yield return unit;
            }
        }
    }
}