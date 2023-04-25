namespace NameSorter.nUnitTests;
using System;
using NUnit.Framework;
using NameSorter;

public class ProgramTest
{
    private string unsortedDefault;
    private string sortedDefault;
    private string onePerson;
    private string nullPerson;
    private string lastNamesOnly;
    private string nullSolution; 

    List<Person> people = new List<Person>();
    List<Person> sortedPeople = new List<Person>();

    [SetUp]
    public void Setup()
    {
        Clear();
        //Path of test files
        unsortedDefault = "testCases/unsortedDefault.txt";
        onePerson = "testCases/onePerson.txt";
        nullPerson = "testCases/null.txt";
        lastNamesOnly = "testCases/lastNames.txt";

        //Path of test files solutions
        sortedDefault = "testExpectedSolutions/sortedDefault.txt";
        nullSolution = "testExpectedSolutions/nullSolution.txt";
    }

    public void Clear()
    {
        people.Clear();
        sortedPeople.Clear();
    }

    [Test]
    public void processFileTest()
    {

        Program.ProcessFile(people, onePerson);
        Assert.That(people.FirstOrDefault().ToString(), Is.EqualTo("John Smith"));
    }

    [Test]
    public void givenNamesTest()
    {
        
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
    public void sortNamesNullTest()
    {
        try
        {
            Program.ProcessFile(people, nullPerson);
            Program.ProcessFile(sortedPeople, nullSolution);
            IOrderedEnumerable<Person> sortedNames = Program.sortNames(people);
            Assert.That(sortedNames.ToList(), Is.EqualTo(sortedPeople));

        }
        catch (Exception e)
        {
            Assert.Fail();
        }
    }

    [Test]
    public void sortNames()
    {

    }

    [Test]
    public void writeToNewFileTest()
    {
        //try
        //{
        //    Program.ProcessFile(sortedPeople, sortedDefault);
        //    Program.WriteToNewFile(sortedPeople);
        //}
        //catch
        //{

        //}
    }

}
