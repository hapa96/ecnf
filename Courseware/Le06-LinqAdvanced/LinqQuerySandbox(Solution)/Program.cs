using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqQuerySandbox
{
    internal class Program
    {
        private static void Main()
        {
            var persons = FillPersons();

            // Todo: Implement queries
            #region Call of Sample Solutions

            var enumerable = persons as Person[] ?? persons.ToArray();

            Task_1_1(enumerable);

            Task_1_2(enumerable);

            Task_1_3(enumerable);

            Task_1_4(enumerable);

            Task_1_5(enumerable);

            Task_1_6(enumerable);

            Task_2_a(enumerable);

            Task_2_b(enumerable);

            Task_2_c(enumerable);

            Task_2_d(enumerable);

            Task_2_e(enumerable);

            Task_3_c1(enumerable);

            Task_3_c2(enumerable);
            #endregion
            Console.ReadLine();

            var customers = FillPersons();
            var contacts =
            customers
            .Where(c => c.City == "Windisch").OrderBy(c => c)
            .Select(c => new { c });

        }


        #region Sample_Solutions Task 1

        static private void Task_1_1(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_1);

            if (persons.Any(p => p.FirstName == "Martin"))
            {
                Console.WriteLine("There is a person with my name.");
            }
            else
            {
                Console.WriteLine("There is no person with my name.");
            }

        }

        static private void Task_1_2(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_2);
            var cars = persons.SelectMany(p => p.Cars).Count();
            Console.WriteLine($"There are {cars} cars");
        }

        static private void Task_1_3(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_3);
            bool allHasAtLeastOneCar = persons.All(p => p.Cars.Count >= 1);

            Console.WriteLine($"All persons have at least 1 car is {allHasAtLeastOneCar}");
        }

        static private void Task_1_4(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_4);
            var managerCarModel = persons.OfType<Manager>().SelectMany(p => p.Cars).Select(c => c.Model).Distinct();

            foreach (var model in managerCarModel)
            {
                Console.WriteLine(model);
            }

        }

        static private void Task_1_5(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_5);
            var firstNameFirstLetters = persons.Select(p => p.FirstName[0]).Distinct();
//            var firstNameFirstLetters = persons.Select(p => p.FirstName.Take(1).First()).Distinct();

            foreach (var firstLetter in firstNameFirstLetters)
            {
                Console.WriteLine(firstLetter);
            }

        }

        static private void Task_1_6(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_6);
            var sortedPersons = persons.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ThenBy(p => p.Cars.Count);

            foreach (var person in sortedPersons)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} has {person.Cars.Count} cars.");
            }

        }

        #endregion

        #region Sample_Solutions Task 2
        static private void Task_2_a(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_a);

            var groupedPersons = persons.GroupBy(p => p.FirstName).OrderBy(p => p.Key);

            foreach (var personGroup in groupedPersons)
            {
                Console.WriteLine($"Number of entries: {personGroup.Count()} of {personGroup.Key}");
            }
        }

        private static void Task_2_b(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_b);

            var bills = persons.Where(p => p.FirstName == "Bill");
            var enumerable = bills.ToArray();
            var firstBill = enumerable.OrderBy(p => p.LastName).First();

            var bills2 = persons.Where(p => p.FirstName == "Bill").OrderBy(p => p.LastName).First();

            foreach (var p in enumerable)
            {
                Console.WriteLine($"{p.LastName}");
            }

            Console.WriteLine($"First Bill is {firstBill.LastName}");

        }

        static private void Task_2_c(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_c);

            var averageCars = persons.Average(p => p.Cars.Count);

            Console.WriteLine($"A person has {averageCars} cars in average");

        }

        static private void Task_2_d(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_d);

            var mostFrequentColor = persons.SelectMany(p => p.Cars)
                .GroupBy(c => c.Color)
                .OrderByDescending(co => co.Count())
                .First();

            Console.WriteLine($"{mostFrequentColor.Key} is the most frequent color ({mostFrequentColor.Count()} times)");

        }

        static private void Task_2_e(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_e);

            double[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = numbers.AwesomeSelect(n => n * Math.PI);

            foreach (var value in result)
            {
                Console.Write($"{value} ");
                Console.WriteLine();
            }
            

        }


        #endregion

        #region Sample_Solutions Task 3
        static private void Task_3_c1(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_3_c1);

            var myNameExists = (from person in persons
                               where (person.FirstName == "Martîn")
                               select person).Any();

            if (myNameExists)
            {
                Console.WriteLine("There is a person with my name.");
            }
            else
            {
                Console.WriteLine("There is no person with my name.");
            }

        }

        static private void Task_3_c2(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_3_c2);
            var cars = (from person in persons from car in person.Cars select car).Count() ;
            Console.WriteLine($"There are {cars} cars");
        }

        #endregion
        static void WriteTaskHeader(Action<IEnumerable<Person>> method)
        {
                Console.WriteLine($"\n{method.Method.Name}\n{new string( '=', method.Method.Name.Length)}");

        }

        private static IEnumerable<Person> FillPersons()
        {
            return new List<Person>
            {
                new Person
                {
                    FirstName = "Joe",
                    LastName = "Adams",
                    City = "Sacromento",
                    Cars = new List<Car> {new Car {Model = "Opel Manta", Color = "Yellow"}, new Car {Model = "VW Golf", Color = "Green"}}
                },
                new Person
                {
                    FirstName = "Don",
                    LastName = "Alexander",
                    City = "Washington",
                    Cars = new List<Car> {new Car {Model = "Tesla", Color = "Red"}}
                },
                new Manager
                {
                    FirstName = "Dave",
                    LastName = "Ashton",
                    City = "Seattle",
                    Cars = new List<Car> {new Car {Model = "Mercedes", Color = "Black"}, new Car {Model = "Porsche", Color = "Green"}}
                },
                new Person
                {
                    FirstName = "Bill",
                    LastName = "Pierce",
                    City = "Sacromento",
                    Cars = new List<Car> 
                    {
                        new Car {Model = "Dodge Challanger Hellcat", Color = "White"},
                        new Car {Model = "Subaru", Color = "White"}
                    }
                },
                new Manager
                {
                    FirstName = "Bill",
                    LastName = "Giard",
                    City = "Seattle",
                    Cars = new List<Car> 
                    {
                        new Car {Model = "Porsche", Color = "Yellow"},
                        new Car {Model = "BMW", Color = "Green"}
                    }
                }
            };
        }

    }
}
