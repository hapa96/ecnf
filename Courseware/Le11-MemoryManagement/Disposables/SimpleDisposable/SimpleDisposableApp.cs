using System;

namespace SimpleDisposable
{
    class SimpleDisposableApp
    {
        static void Main(string[] args)
        {
            DemoResourceManagement();
            GC.Collect();

        }

        private static void DemoResourceManagement()
        {
            var nf = new LogFileReader("TextFile.txt");

            Console.WriteLine("Hello World!");

        }
    }
}
