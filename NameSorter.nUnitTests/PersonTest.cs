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

    [Test]
    public void EqualsTest()
    {
        var personA = new Person("John Jr", "Smith");
        var personB = new Person("John Jr", "Smith");
        var personC = new Person("John", "Jr Smith");
        var personD = new Person("Smith", "John Jr");

        Assert.That(personB, Is.EqualTo(personA));
        Assert.That(personC, Is.Not.EqualTo(personA));
        Assert.That(personC, Is.Not.EqualTo(personD));
    }
}