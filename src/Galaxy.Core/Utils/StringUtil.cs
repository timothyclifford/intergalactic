using System;

namespace Galaxy.Core.Utils
{
    /// <summary>
    /// Utility class for working with strings
    /// </summary>
    public class StringUtil
    {
        /// <summary>
        /// Splits a string by spaces
        /// </summary>
        /// <param name="value">
        /// The raw string value
        /// </param>
        /// <returns>
        /// A list of strings containing the split segments
        /// </returns>
        public static string[] SplitBySpaces(string value)
        {
            return value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}