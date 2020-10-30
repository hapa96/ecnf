using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LINQtoSQLExample
{
    class Program
    {
        private static DbContextOptionsBuilder<Context> _dbOptions;

        static void Main(string[] args)
        {
            // TODO: set your path to db -> without file name! 
            string absolutePathToDb = @"C:\Users\pascal.hauser1\Documents\repos\ecnf\Courseware\Le06-LinqAdvanced\LINQtoSQLExample(Stud)\LINQtoSQLExample(Stud)\LINQtoSQLExample";
            _dbOptions = new DbContextOptionsBuilder<Context>();
            _dbOptions
                .UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={absolutePathToDb}\Database.mdf;Integrated Security=True")
                .UseLoggerFactory(new LoggerFactory(new List<ILoggerProvider> { new TraceLoggerProvider() }));

            using (var dbx = new Context(_dbOptions.Options))
            {
                
                foreach (var p in dbx.Persons)
                {
                    var query = dbx.Persons.Where(x => x.PartnerId == p.PartnerId).Where(x => x.FirstName != p.FirstName).FirstOrDefault();
                    Console.WriteLine($"{ p.FirstName} {p.LastName} Parner: {query?.FirstName}");
                }
                    
            }

            Console.ReadKey();
        }
    }
}
