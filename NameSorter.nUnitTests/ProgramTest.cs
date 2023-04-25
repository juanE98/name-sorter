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
    private string smallListSolution;
    private string smallList; 
    private StringWriter stringWriter;
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
        smallList = "testCases/smallList.txt";

        //Path of test files solutions
        sortedDefault = "testExpectedSolutions/sortedDefault.txt";
        nullSolution = "testExpectedSolutions/nullSolution.txt";
        smallListSolution = "testExpectedSolutions/sortedSmallList.txt";

        stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
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
    public void writeToNewFileTest()
    {
        try
        {
            Program.ProcessFile(sortedPeople, smallListSolution);
            IOrderedEnumerable<Person> sortedNames = Program.sortNames(sortedPeople);
            Program.WriteToNewFile(sortedNames);

            var output = stringWriter.ToString();
            Assert.That(output, Is.EqualTo("Adonis Julius Archer\nVaughn Lewis\nJanet Parsons\n"));
        }
        catch
        {
            Assert.Fail();
        }
    }
}
