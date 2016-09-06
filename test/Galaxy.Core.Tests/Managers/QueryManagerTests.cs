using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

using Galaxy.Core.Managers;
using Galaxy.Core.Models;

namespace Galaxy.Core.Tests.Managers
{
    public class QueryManagerTests
    {
        [Fact]
        public void GivenListOfValidQuestions_GetAnswers_ReturnsListOfAnswers()
        {
            var queryManager = new QueryManager();
            var notes = new Notes();
            notes.Units.Add(new Unit("unit", Symbol.X));
            notes.Resources.Add(new Resource("resource", "unit unit", 100));
            notes.Questions.Add(new UnitQuestion("unit unit"));
            notes.Questions.Add(new ResourceQuestion("unit unit", "resource"));
            notes.Questions.Add(new ResourceQuestion("unit", "resource"));

            var answers = queryManager.GetAnswers(notes);

            Assert.NotNull(answers);
            Assert.Equal(3, answers.Count());
            Assert.Equal("unit unit is 20", answers.ElementAt(0));
            Assert.Equal("unit unit resource is 100 Credits", answers.ElementAt(1));
            Assert.Equal("unit resource is 50 Credits", answers.ElementAt(2));
        }

        [Fact]
        public void GivenListOfInvalidQuestions_GetAnswers_ReturnsListOfInvalidAnswers()
        {
            var queryManager = new QueryManager();
            var notes = new Notes();
            notes.Units.Add(new Unit("unit", Symbol.X));
            notes.Resources.Add(new Resource("resource", "unit unit", 100));
            notes.Questions.Add(new ResourceQuestion("invalid", "resource"));
            notes.Questions.Add(new ResourceQuestion("unit", "invalid"));

            var answers = queryManager.GetAnswers(notes);

            Assert.NotNull(answers);
            Assert.Equal(2, answers.Count());
            Assert.Equal("I have no idea what you are talking about", answers.ElementAt(0));
            Assert.Equal("I have no idea what you are talking about", answers.ElementAt(1));
        }

        [Fact]
        public void GivenValidUnitQuestion_AnswerUnitQuestion_ReturnsCorrectAnswer()
        {
            var queryManager = new QueryManager();
            var unitQuestion = new UnitQuestion("borg shmorg");
            var notes = new Notes();
            notes.Units.Add(new Unit("borg", Symbol.C));
            notes.Units.Add(new Unit("shmorg", Symbol.X));

            var answer = queryManager.AnswerUnitQuestion(unitQuestion, notes);

            Assert.NotNull(answer);
            Assert.Equal("borg shmorg is 110", answer);
        }

        [Fact]
        public void GivenInvalidUnitQuestion_AnswerUnitQuestion_ReturnsNull()
        {
            var queryManager = new QueryManager();
            var unitQuestion = new UnitQuestion("borg shmorg");
            var notes = new Notes();

            var answer = queryManager.AnswerUnitQuestion(unitQuestion, notes);

            Assert.Null(answer);
        }

        [Fact]
        public void GivenValidResourceQuestion_AnswerResourceQuestion_ReturnsCorrectAnswer()
        {
            var queryManager = new QueryManager();
            var resourceQuestion = new ResourceQuestion("borg shmorg", "resource");
            var notes = new Notes();
            notes.Units.Add(new Unit("borg", Symbol.C));
            notes.Units.Add(new Unit("shmorg", Symbol.X));
            notes.Resources.Add(new Resource("resource", "borg", 100));

            var answer = queryManager.AnswerResourceQuestion(resourceQuestion, notes);

            Assert.NotNull(answer);
            Assert.Equal("borg shmorg resource is 110 Credits", answer);
        }

        [Fact]
        public void GivenInvalidResourceQuestion_AnswerResourceQuestion_ReturnsNull()
        {
            var queryManager = new QueryManager();
            var resourceQuestion = new ResourceQuestion("borg shmorg", "resource");
            var notes = new Notes();

            var answer = queryManager.AnswerResourceQuestion(resourceQuestion, notes);

            Assert.Null(answer);
        }

        [Fact]
        public void GivenValidUnits_GetUnitsValue_ReturnsCorrectValue()
        {
            var queryManager = new QueryManager();
            var notes = new Notes();
            notes.Units.Add(new Unit("borg", Symbol.M));
            notes.Units.Add(new Unit("bla", Symbol.C));
            notes.Units.Add(new Unit("quack", Symbol.L));

            var unitsValue = queryManager.GetUnitsValue("borg bla quack", notes);

            Assert.Equal(1150, unitsValue);
        }

        [Fact]
        public void GivenValidResourceName_GetResourceValue_ReturnsCorrectValue()
        {
            var queryManager = new QueryManager();
            var notes = new Notes();
            notes.Units.Add(new Unit("borg", Symbol.M));
            notes.Units.Add(new Unit("bla", Symbol.C));
            notes.Units.Add(new Unit("quack", Symbol.L));
            notes.Resources.Add(new Resource("resource", "bla bla bla", 9000));

            var resourceValue = queryManager.GetResourceValue("resource", notes);

            Assert.Equal(30, resourceValue);
        }

        [Fact]
        public void GivenInvalidResourceName_GetResourceValue_ThrowsException()
        {
            var queryManager = new QueryManager();
            var notes = new Notes();
            notes.Units.Add(new Unit("borg", Symbol.M));
            notes.Units.Add(new Unit("bla", Symbol.C));
            notes.Units.Add(new Unit("quack", Symbol.L));
            notes.Resources.Add(new Resource("resource", "bla bla bla", 9000));
            
            var exception = Record.Exception(() => queryManager.GetResourceValue("invalid", notes));
            
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }

        [Fact]
        public void GivenValidUnitInput_ConvertUnitsToRomanNumeral_ReturnsRomanNumeral()
        {
            var queryManager = new QueryManager();
            var unitDefinitions = new List<Unit>
            {
                new Unit("bla", Symbol.C),
                new Unit("meep", Symbol.I)
            };

            var romanNumeral = queryManager.ConvertUnitsToRomanNumeral("bla bla meep", unitDefinitions);

            Assert.Equal("CCI", romanNumeral.AsRawString());
        }

        [Fact]
        public void GivenInvalidUnitInput_ConvertUnitsToRomanNumeral_ThrowsException()
        {
            var queryManager = new QueryManager();
            var unitDefinitions = new List<Unit>
            {
                new Unit("bla", Symbol.C),
                new Unit("meep", Symbol.I)
            };
            
            var exception = Record.Exception(() => queryManager.ConvertUnitsToRomanNumeral("meep meep meep bla bla", unitDefinitions));
            
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }
    }
}
