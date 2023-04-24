using System;
using NUnit.Framework;
using NameSorter;

namespace NameSorter.nUnitTests;

public class PersonTest
{
    private Person newPerson;
    private Person lastNameOnly;
    private Person twoNames;

    [SetUp]
    public void Setup()
    {
        newPerson = new Person("John Lee", "Smith");
        lastNameOnly = new Person("", "Smith");
        twoNames = new Person("John", "Smith");
    }

    [Test]
    public void ToStringTest()
    {
        Assert.That(newPerson.ToString(), Is.EqualTo("John Lee Smith"));
        Assert.That(lastNameOnly.ToString(), Is.EqualTo(" Smith"));
        Assert.That(twoNames.ToString(), Is.EqualTo("John Smith"));
    }
}