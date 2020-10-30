using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public string Address;

        public override string ToString() => $"{FirstName} {LastName} {Address}";
    }
}
