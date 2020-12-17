using System;
using System.Threading;

namespace Disposables
{
    class DisposableApp
    {
        static public LogFileReader GlobalReference = null;
        static void Main()
        {
            var nf = new LogFileReader("TextFile.txt");
            nf = null;

            Console.WriteLine("GC collect start");
            GC.Collect();
            Thread.Sleep(1000);
            Console.WriteLine("GC collect end");

            //GC.ReRegisterForFinalize(GlobalReference);

            GlobalReference?.PrintAliveMessage();
            Console.WriteLine("GC collect start");
            GC.Collect();
            Thread.Sleep(1000);
            Console.WriteLine("GC collect end");

            GlobalReference?.PrintAliveMessage();

            

            Console.WriteLine("GC collect start");
            GC.Collect();
            Thread.Sleep(1000);
            Console.WriteLine("GC collect end");

            Console.ReadKey();
        }
    }
}
