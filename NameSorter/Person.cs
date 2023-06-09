﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameSorter;

namespace NameSorter
{
    public class Person
    {
        public string givenName { get; set; }
        public string lastName { get; set; }

        public Person(string givenNames, string lastName)
        {
            givenName = givenNames;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return $"{givenName} {lastName}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Person other = obj as Person;
            return this.givenName == other.givenName && this.lastName == other.lastName;
        }
    }
}
