using static System.Console;

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

using Galaxy.Core.Factories;
using Galaxy.Core.Managers;

namespace Galaxy.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Init configuration from JSON file and command line arguments
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", false, true)
                .AddCommandLine(args)
                .Build(); 

            if (string.IsNullOrWhiteSpace(configuration["filename"]))
            {
                WriteLine("Please supply a filename");
                return;
            }

            var input = ReadFromFile(configuration["filename"]);
            if (input == null)
            {
                WriteLine("Exiting...");
                return;
            }
            else if (input.Count == 0)
            {
                WriteLine("File is empty");
                WriteLine("Exiting...");
                return;
            }
            
            // Parse file input into notes
            var notesManager = new NotesManager
            (
                new UnitFactory(configuration["regex:definitions:unit"]),
                new ResourceFactory(configuration["regex:definitions:resource"]),
                new UnitQuestionFactory(configuration["regex:questions:unit"]),
                new ResourceQuestionFactory(configuration["regex:questions:resource"])
            );
            var notes = notesManager.PopulateNotesFromInput(input);

            // Using the populated notes, figure out and display the answers
            var queryManager = new QueryManager();
            foreach (var answer in queryManager.GetAnswers(notes))
            {
                WriteLine(answer);
            }
        }

        /// <summary>
        /// Reads file contents
        /// </summary>
        /// <param name="file">
        /// The file path
        /// </param>
        /// <returns>
        /// A list of strings containing all file lines
        /// </returns>
        static IList<string> ReadFromFile(string file)
        {
            try
            {
                return File.ReadAllLines(file);
            }
            catch (FileNotFoundException)
            {
                WriteLine($"File {file} does not exist");
            }
            catch (Exception e)
            {
                WriteLine($"Exception thrown trying to read {file}: {e.Message}");
            }

            return null;
        }
    }
}
