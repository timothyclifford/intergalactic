using System.Collections.Generic;

using Galaxy.Core.Factories;
using Galaxy.Core.Models;

namespace Galaxy.Core.Managers
{
    /// <summary>
    /// Parses input into notes
    /// </summary>
    public class NotesManager
    {
        private UnitFactory _unitFactory;
        
        private ResourceFactory _resourceFactory;
        
        private UnitQuestionFactory _unitQuestionFactory;
        
        private ResourceQuestionFactory _resourceQuestionFactory;

        public NotesManager(
            UnitFactory unitFactory,
            ResourceFactory resourceFactory,
            UnitQuestionFactory unitQuestionFactory,
            ResourceQuestionFactory resourceQuestionFactory
        )
        {
            _unitFactory = unitFactory;
            _resourceFactory = resourceFactory;
            _unitQuestionFactory = unitQuestionFactory;
            _resourceQuestionFactory = resourceQuestionFactory;
        }

        /// <summary>
        /// Iterates through each line of input to populate notes 
        /// </summary>
        /// <param name="input">
        /// List of strings containing input lines
        /// </param>
        /// <returns>
        /// A populated Notes object
        /// </returns>
        public Notes PopulateNotesFromInput(IList<string> input)
        {
            var notes = new Notes();

            // Iterate through lines, try and create object for each
            // If able to create, add to notes and move to next
            // Otherwise try to create next object
            // If no objects able to be created, assume invalid input
            foreach (var line in input)
            {
                var unit = _unitFactory.Create(line);
                if (unit != null)
                {
                    notes.Units.Add(unit);
                    continue;
                }

                var resource = _resourceFactory.Create(line);
                if (resource != null)
                {
                    notes.Resources.Add(resource);
                    continue;
                }

                var unitQuestion = _unitQuestionFactory.Create(line);
                if (unitQuestion != null)
                {
                    notes.Questions.Add(unitQuestion);
                    continue;
                }

                var resourceQuestion = _resourceQuestionFactory.Create(line);
                if (resourceQuestion != null)
                {
                    notes.Questions.Add(resourceQuestion);
                    continue;
                }

                notes.Questions.Add(new InvalidQuestion());
            }

            return notes;
        }
    }
}