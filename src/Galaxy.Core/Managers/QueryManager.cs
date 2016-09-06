using System;
using System.Collections.Generic;
using System.Linq;

using Galaxy.Core.Models;
using Galaxy.Core.Utils;

namespace Galaxy.Core.Managers
{
    /// <summary>
    /// Generates answers using notes
    /// </summary>
    public class QueryManager
    {
        /// <summary>
        /// Iterates through note questions and generates answers
        /// </summary>
        /// <param name="notes">
        /// The notes
        /// </param>
        /// <returns>
        /// A list of answer strings
        /// </returns>
        public IEnumerable<string> GetAnswers(Notes notes)
        {
            foreach (var question in notes.Questions)
            {
                string answer = null;

                if (question is UnitQuestion)
                {
                    answer = AnswerUnitQuestion((UnitQuestion)question, notes);
                }
                else if (question is ResourceQuestion)
                {
                    answer = AnswerResourceQuestion((ResourceQuestion)question, notes);
                }

                yield return answer ?? "I have no idea what you are talking about";
            }
        }

        /// <summary>
        /// Generates answer to unit question
        /// </summary>
        /// <param name="question">
        /// The unit question
        /// </param>
        /// <param name="notes">
        /// The notes containing unit and resource definitions
        /// </param>
        /// <returns>
        /// The answer string if question is valid otherwise null
        /// </returns>
        public string AnswerUnitQuestion(UnitQuestion question, Notes notes)
        {
            try
            {
                var unitsValue = GetUnitsValue(question.Units, notes);

                return $"{question.Units} is {unitsValue}";
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Generates answer to resource question
        /// </summary>
        /// <param name="question">
        /// The resource question
        /// </param>
        /// <param name="notes">
        /// The notes containing unit and resource definitions
        /// </param>
        /// <returns>
        /// The answer string if question is valid otherwise null
        /// </returns>
        public string AnswerResourceQuestion(ResourceQuestion question, Notes notes)
        {
            try
            {
                var unitsValue = GetUnitsValue(question.Units, notes);
                var resourceValue = GetResourceValue(question.Resource, notes);
                var credits = unitsValue * resourceValue;

                return $"{question.Units} {question.Resource} is {credits} Credits";
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Calculates value of units
        /// </summary>
        /// <param name="unitNames">
        /// The unit names
        /// </param>
        /// <param name="notes">
        /// The notes containing unit and resource definitions
        /// </param>
        /// <returns>
        /// The value of the unit names
        /// </returns>
        public float GetUnitsValue(string unitNames, Notes notes)
        {
            var romanNumeral = ConvertUnitsToRomanNumeral(unitNames, notes.Units);

            return romanNumeral.Calculate();
        }

        /// <summary>
        /// Calculates value of a resource
        /// </summary>
        /// <param name="resourceName">
        /// The resource name
        /// </param>
        /// <param name="notes">
        /// The notes containing unit and resource definitions
        /// </param>
        /// <returns>
        /// The value of the resource
        /// </returns>
        public float GetResourceValue(string resourceName, Notes notes)
        {
            var resource = notes.Resources.FirstOrDefault(r => r.Name.Equals(resourceName, StringComparison.OrdinalIgnoreCase));
            if (resource == null)
            {
                throw new ArgumentException($"No definition provided for resource {resourceName}");
            }

            // A resource contains a collection of units, a resource name and total credits
            // eg. beep boop Gold is 500 Credits
            // Total credits is a product of the resource and units
            // So we first need to convert the units to a roman numeral
            var romanNumeral = ConvertUnitsToRomanNumeral(resource.Units, notes.Units);

            // Then dividing the total credits by the roman numeral value
            return resource.Credits / romanNumeral.Calculate();
        }

        /// <summary>
        /// Converts a string of one or more units to a roman numeral
        /// </summary>
        /// <param name="unitNames">
        /// The unit names
        /// </param>
        /// <param name="unitDefinitions">
        /// The strongly typed unit definitions
        /// </param>
        /// <returns>
        /// A roman numeral representation of the units
        /// </returns>
        public RomanNumeral ConvertUnitsToRomanNumeral(string unitNames, IEnumerable<Unit> unitDefinitions)
        {
            var units = UnitUtil.GetByNames(unitNames, unitDefinitions);
            var romanNumeral = new RomanNumeral(units);
            if (!romanNumeral.IsValid())
            {
                throw new ArgumentException("Symbols do not make up a valid roman numeral");
            }

            return romanNumeral;
        }
    }
}