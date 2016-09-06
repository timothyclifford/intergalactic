using System.Collections.Generic;
using Xunit;

using Galaxy.Core.Factories;
using Galaxy.Core.Managers;

namespace Galaxy.Core.Tests.Managers
{
    public class NotesManagerTests
    {
        public class PopulateNotesFromInput
        {
            private NotesManager _notesManager;

            public PopulateNotesFromInput()
            {
                _notesManager = new NotesManager
                (
                    new UnitFactory(TestSettings.UnitPattern),
                    new ResourceFactory(TestSettings.ResourcePattern),
                    new UnitQuestionFactory(TestSettings.UnitQuestionPattern),
                    new ResourceQuestionFactory(TestSettings.ResourceQuestionPattern)
                );
            }

            [Fact]
            public void GivenEmptyInput_ReturnsEmptyNotes() 
            {
                var notes = _notesManager.PopulateNotesFromInput(new List<string>());
                
                Assert.NotNull(notes);
                Assert.Equal(0, notes.Units.Count);
                Assert.Equal(0, notes.Resources.Count);
                Assert.Equal(0, notes.Questions.Count);
            }
            
            [Fact]
            public void GivenValidInput_ReturnsPopulatedNotes() 
            {
                var input = new List<string>
                {
                    "glob is I",
                    "prok is V",
                    "pish is X",
                    "tegj is L",
                    "glob glob Silver is 34 Credits",
                    "how much is pish tegj glob glob ?",
                    "how many Credits is glob prok Silver ?"
                };
                
                var notes = _notesManager.PopulateNotesFromInput(input);
                
                Assert.NotNull(notes);
                Assert.Equal(4, notes.Units.Count);
                Assert.Equal(1, notes.Resources.Count);
                Assert.Equal(2, notes.Questions.Count);
            }
        }
    }
}
