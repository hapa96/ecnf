using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Program
    {
        readonly static private List<Person> persons = new List<Person>
            {
                new Person {FirstName = "Joe", LastName = "Adams", Address = "Chandler"},
                new Person {FirstName = "Don", LastName = "Alexander", Address = "Washington"},
                new Person {FirstName = "Dave", LastName = "Ashton", Address = "Seattle"},
                new Person {FirstName = "Bill", LastName = "Pierce", Address = "Sacromento"},
                new Person {FirstName = "Bill", LastName = "Giard", Address = "Camphill"}
            };

        static void Main()
        {
            //a linq query over the persons-list
            var personsInCity = persons
                .Where(person => person.Address == "Washington")
                .OrderBy(person => person.FirstName);

            //print the linq results
            Console.WriteLine("Person list (original):");
            foreach (var person in personsInCity)
                Console.WriteLine($"   {person}");
            Console.WriteLine();

            //add a new person to the persons list
            persons.Add(new Person
            {
                FirstName = "Ron",
                LastName = "Miller",
                Address = "Washington"
            });

            //print the linq results again
            Console.WriteLine("Person list (modified):");
            foreach (var person in personsInCity)
                Console.WriteLine($"   {person}");
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
