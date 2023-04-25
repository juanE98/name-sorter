namespace NameSorter.nUnitTests;
using System;
using NUnit.Framework;
using NameSorter;

public class ProgramTest
{
    private string unsortedDefault;
    private string sortedDefault;
    [SetUp]
    public void Setup()
    {
        //Path of test files
        unsortedDefault = "testCases/unsortedDefault.txt";


        //Path of test files solutions
        sortedDefault = "testExpectedSolutions/sortedDefault.txt";
    }

    [Test]
    public void givenNamesTest()
    {
        List<Person> people = new List<Person>();
        List<Person> sortedPeople = new List<Person>();
        try
        {
            Program.ProcessFile(people, unsortedDefault);
            Program.ProcessFile(sortedPeople, sortedDefault);
            IOrderedEnumerable<Person> sortedNames = Program.sortNames(people);
            
            Assert.That(sortedNames.ToList(), Is.EqualTo(sortedPeople));

        }
        catch (Exception e)
        {
            Assert.Fail();
        }
    }

    [Test]
    public void writeToNewFileTest()
    {

    }

    [Test]
    public void processFileTest()
    {

    }

    [Test]
    public void sortNamesNullTest()
    {

    }

    [Test]
    public void sortNames()
    {

    }
}
