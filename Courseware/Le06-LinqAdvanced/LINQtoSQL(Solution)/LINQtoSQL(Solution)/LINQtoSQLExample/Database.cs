using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LINQtoSQLExample
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Cars> Cars { get; set; }
        public DbSet<Persons> Persons { get; set; }
    }

    public class TraceLogger : ILogger
    {
        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            Console.WriteLine(formatter(state, exception));
            Console.WriteLine("-----------------------------------------------------------------");
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }

    public class TraceLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new TraceLogger();

        public void Dispose() { }
    }

    public class Cars
    {
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public string Model { get; set; }
        public Persons Owner { get; set; }
    }

    public class Persons
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PartnerId { get; set; }
        [InverseProperty("Owner")]
        public List<Cars> Cars { get; set; }
    }


}
