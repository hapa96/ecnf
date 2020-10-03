using System;
using System.Reflection;
using PersonAdminLib;

namespace Tutorial
{
    class PersonAdminApplication
    {
        static void Main(string[] args)
        {
 
            // Simple personRegister test
            var personRegister = new PersonRegister();
            Console.WriteLine($"First Person: {personRegister[0].Firstname} {personRegister[0].Surname}");

            Console.WriteLine("Last Person: {0} {1}",
                personRegister[personRegister.Count - 1].Firstname,
                personRegister[personRegister.Count - 1].Surname);


            Console.WriteLine("###Firstname");
            personRegister.Sort(CompareByFirstname);
            personRegister.PrintPersons();
            Console.WriteLine("###Lastname");
            personRegister.Sort(CompareByLastname);
            personRegister.PrintPersons();








        }

        static int CompareByFirstname(Person p1, Person p2) { return p1.Firstname.CompareTo(p2.Firstname); }

        static int CompareByLastname(Person p1, Person p2) { return p1.Surname.CompareTo(p2.Surname); }

        
    }
}