using System;
using System.Reflection;
using PersonAdminLib;

namespace Tutorial
{
    class PersonAdminApplication
    {
        static void Main(string[] args)
        {
            Person Pascal = new Person("Pascal", "Hauser");
            Console.WriteLine(Pascal.Firstname + Pascal.Surname);
            string s = $"My Name is {Pascal.Firstname}";
            Console.WriteLine(s);
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}