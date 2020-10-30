using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LinqQuerySandbox
{
    internal class Program
    {
        private static void Main()
        {
            var persons = FillPersons();

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
        }


        #region Sample_Solutions Task 1

        static private void Task_1_1(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_1);
            // Eine Person in der Liste heisst Pascal
            var sameName = persons.Any(x => x.FirstName == "Pascal");
            Console.WriteLine(sameName);
        }

        static private void Task_1_2(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_2);
            var allCars = persons.SelectMany(x => x.Cars).Count();
            Console.WriteLine($"All Cars: {allCars}");
        }

        static private void Task_1_3(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_3);
            var allPersonsHaveAtLeastOneCar = persons.All(x => x.Cars.Count() > 0);
            Console.WriteLine($"All Persons have at least one car: {allPersonsHaveAtLeastOneCar}");
        }

        static private void Task_1_4(IEnumerable<Person> persons)
        {
            //TODO
            WriteTaskHeader(Task_1_4);
            // var  managerCars = persons.Where(x => x.
        }

        static private void Task_1_5(IEnumerable<Person> persons)
        {
            //TODO
            WriteTaskHeader(Task_1_5);
            var firstLettersOfName = persons.Select(x => x.FirstName); 
            Console.WriteLine($"All first Letters of Names: {firstLettersOfName}");
        }

        static private void Task_1_6(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_1_6);
            var sortedList = persons.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ThenBy(x => x.Cars.Count());
            foreach (var item in sortedList)
            {
                Console.WriteLine(item.FirstName + " "+ item.LastName);
            }
        }

        #endregion

        #region Sample_Solutions Task 2
        static private void Task_2_a(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_a);
            //var groupedSortedNames = persons.GroupBy(k => k.FirstName)
        }

        private static void Task_2_b(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_b);
            Console.WriteLine(persons.Where(x => x.FirstName == "Bill").OrderBy(x => x.LastName).First());
        }

        static private void Task_2_c(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_c);
            Console.WriteLine($"Average cars per Person: {persons.Average(p => p.Cars.Count())}");
            //Console.WriteLine($"Most choosen Colour for Car{persons.SelectMany(c => c.Cars).GroupBy(x => x.Color).).First()}");

        }

        static private void Task_2_d(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_d);
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var result = numbers.AwesomeSelect(n => n * π).ToArray();
        }

        static private void Task_2_e(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_2_e);
			//TODO: Your code here
        }


        #endregion

        #region Sample_Solutions Task 3
        static private void Task_3_c1(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_3_c1);
			//TODO: Your code here
        }

        static private void Task_3_c2(IEnumerable<Person> persons)
        {
            WriteTaskHeader(Task_3_c2);
			//TODO: Your code here
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
