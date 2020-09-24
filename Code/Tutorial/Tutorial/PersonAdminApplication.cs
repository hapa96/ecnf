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

            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}