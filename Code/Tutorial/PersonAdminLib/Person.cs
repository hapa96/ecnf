using System;
using System.Collections.Generic;
using System.Text;

namespace PersonAdminLib
{
    public class Person
    {
        public string Firstname { get; }
        public string Surname { get; }

        public Person(string firstname, string surname)
        {
            Firstname = firstname;
            Surname = surname;
        }

    }
}
