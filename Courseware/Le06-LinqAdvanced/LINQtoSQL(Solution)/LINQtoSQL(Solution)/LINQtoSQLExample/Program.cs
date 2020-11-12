using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LINQtoSQLExample
{
    class Program
    {


        static void Main()
        {
            string absolutePathToDb = @"C:\yves\fhnw\ecnf\trunk\documents\handouts\Le06-LinqAdvanced\LINQtoSQLExample(Stud)\LINQtoSQLExample";
            _dbOptions = new DbContextOptionsBuilder<Context>();
            _dbOptions
                .UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={absolutePathToDb}\Database.mdf;Integrated Security=True")
                .UseLoggerFactory(new LoggerFactory(new List<ILoggerProvider>{ new TraceLoggerProvider()}));
            

            using (var dbx = new Context(_dbOptions.Options))
            {
                foreach (var p in dbx.Persons)
                    Console.WriteLine($"{ p.FirstName} {p.LastName}");
            }

            Task_4_09();

            Task_4_10();

            Task_4_11Database();

            Task_3_12Object();

            Console.ReadKey();

        }
        
        private static void Task_4_09()
        {
            Console.WriteLine("Task 4-09:");
            using (var dbx = new Context(_dbOptions.Options))
            {
                foreach (var p in dbx.Persons.Include(c => c.Cars))
                {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                    
                    foreach (Cars car in p.Cars)
                    {
                        Console.WriteLine($"    Car name: {car.Model}");
                    }
                }                    
            }
        }

        private static void Task_4_10()
        {
            Console.WriteLine("Task 4-10:");
            using (var dbx = new Context(_dbOptions.Options))
            {
                var query = dbx.Persons.Where(p => p.FirstName.StartsWith("Ma"));
                //var query = dbx.Persons.Where(p => p.FirstName.StartsWith("Ma", StringComparison.InvariantCultureIgnoreCase));

                foreach (var p in query)
                {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                }
            }
        }

        private static void Task_4_11Database()
        {
            using (var dbx = new Context(_dbOptions.Options))
            {
                var p = dbx.Persons.First();
                p.LastName = "Test";
                Console.WriteLine($"Inside same data context: {p.LastName}");
                dbx.SaveChanges();
            }

            using (var dbx = new Context(_dbOptions.Options))
            {
                var p = dbx.Persons.First();
                Console.WriteLine($"From another data context: {p.LastName}");
            }
        }

        #region LinqToObject Demo to demonstrate the different results on queries compared to the above example
        private static List<Persons> pList = new List<Persons>
        {
            new Persons() {FirstName = "Martin", LastName = "Kropp"},
            new Persons() {FirstName = "Michael", LastName = "Schnyder"},
            new Persons() {FirstName = "Simon", LastName = "Felix"}
        };

        private static DbContextOptionsBuilder<Context> _dbOptions;

        private static void Task_3_12Object()
        {
            {
                var p = pList.First();
                p.LastName = "Test";
                Console.WriteLine($"Inside same object context: {p.LastName}");
            }

            { 
                var p = pList.First();
                Console.WriteLine($"From another object context: {p.LastName}");
            }
        }

#endregion

    }
}
