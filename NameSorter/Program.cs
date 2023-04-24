using System.Linq;
using System.Collections.Generic;
using NameSorter;


namespace NameSorter
{
    public class Program
    {       
        /// <summary>
        /// Main Program 
        /// </summary>
        /// <param name="args"> File path for unsorted list</param>
        static void Main(string[] args)
        {
            string unsortedNamesFile = args[0];
            List<Person> people = new List<Person>();            
            try
            {
                ProcessFile(people, unsortedNamesFile);
                IOrderedEnumerable<Person> sortedNames = sortNames(people);
                WriteToNewFile(sortedNames);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }
        }

        /// <summary>
        /// Writes to txt file in working directory the output of the sorted list
        /// </summary>
        /// <param name="sortedNames"> List of sorted names</param>
        private static void WriteToNewFile(IOrderedEnumerable<Person> sortedNames)
        {
            using (StreamWriter sw = File.CreateText("sorted-names-list.txt"))
            {
                foreach (Person name in sortedNames)
                {
                    Console.WriteLine(name.ToString());
                    sw.WriteLine(name.ToString());
                }
            }
        }

        /// <summary>
        /// Reads txt file of unsorted names and adds it to a list 
        /// </summary>
        /// <param name="names"></param>
        private static void ProcessFile(List<Person> names, string unsortedNames)
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), unsortedNames).FirstOrDefault() ?? throw new FileNotFoundException(); 
            
            var lines = File.ReadAllLines(files);
            foreach (var line in lines)
            {
                var name = line.Split(' ');
                var lastName = name.LastOrDefault();
                var givenNames = string.Join(" ", name.Take(name.Length - 1));

                //Create Name object
                Person person = new Person(givenNames, lastName);
                names.Add(person);
            }
        }

        /// <summary>
        /// Sorts a list of Person by last name first then by any given names a person may have.
        /// </summary>
        /// <param name="names">List of unsorted names</param>
        /// <returns>List of sorted names</returns>
        private static IOrderedEnumerable<Person> sortNames(List<Person> names)
        {
            return names.OrderBy(name => name.lastName).ThenBy(name => name.givenName);
        }
    }
}