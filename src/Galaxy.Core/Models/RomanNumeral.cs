using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Galaxy.Core.Models
{
    public class RomanNumeral
    {
        private readonly IEnumerable<Symbol> _symbols;

        public RomanNumeral(IEnumerable<Symbol> symbols)
        {
            _symbols = symbols;
        }

        public RomanNumeral(IEnumerable<Unit> units)
        {
            _symbols = units.Select(u => u.Symbol);
        }

        /// <summary>
        /// Validates the roman numeral symbol composition
        /// </summary>
        /// <returns>
        /// True if valid otherwise false
        /// </returns>
        public bool IsValid()
        {
            var raw = AsRawString();

            // I, X, C and M can only be repeated 3 times max
            if (Regex.IsMatch(raw, "IIII|XXXX|CCCC|MMMM"))
            {
                return false;
            }

            // D, L and V can never be repeated
            if (Regex.IsMatch(raw, "DD|LL|VV"))
            {
                return false;
            }

            // I can be subtracted from V and X only
            if (Regex.IsMatch(raw, "I[LCDM]"))
            {
                return false;
            }

            // X can be subtracted from L and C only
            if (Regex.IsMatch(raw, "X[DM]"))
            {
                return false;
            }

            // V, L and D can never be subtracted
            if (Regex.IsMatch(raw, "V[XLCDM]|L[CDM]|DM"))
            {
                return false;
            }

            // Thought about possibility of repeated symbols with subtraction 
            // ocurring earlier in the sequence rather than last
            // if (Regex.IsMatch(raw, "IVV|IXX|XLL|XCC|CDD|CMM"))
            // {
            //     return false;
            // }

            // Thought about possibility of repeated symbols with subtraction 
            // ocurring earlier in the sequence rather than last
            // if (Regex.IsMatch(raw, "IIV|IIX|XXL|XXC|CCD|CCM"))
            // {
            //     return false;
            // }

            // Thought about possibility of subtraction symbol 
            // ocurring again after subtraction
            // if (Regex.IsMatch(raw, "IVI|IXI|XLX|XCX|CDC|CMC"))
            // {
            //     return false;
            // }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AsRawString()
        {
            return string.Join(string.Empty, _symbols.Select(s => Enum.GetName(typeof(Symbol), s)));
        }

        /// <summary>
        /// Calculates roman numeral integer value 
        /// </summary>
        /// <returns>
        /// Integer value of the roman numeral
        /// </returns>
        public int Calculate()
        {
            if (_symbols == null || _symbols.Count() == 0)
            {
                return 0;
            }

            var total = 0;
            var subtract = 0;

            for (var x = 0; x < _symbols.Count(); x++)
            {
                var current = (int)_symbols.ElementAt(x);
                var next = ((x + 1) < _symbols.Count()) 
                    ? (int)_symbols.ElementAt(x + 1)
                    : 0;

                // If current symbol value is smaller than next, 
                // this will be subtracted in the following iteration
                if (current < next)
                {
                    subtract = current;
                }
                else
                {
                    total += current - subtract;
                    subtract = 0;
                }
            }

            return total;
        }
    }
}