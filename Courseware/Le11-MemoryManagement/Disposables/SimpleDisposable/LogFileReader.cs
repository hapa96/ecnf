using System;
using System.IO;

namespace SimpleDisposable
{
    /// <summary>
    /// this class is supposed to constantly read from the passed
    /// log file.
    /// </summary>
    class LogFileReader
    {
        private TextReader logFile;

        /// <summary>
        /// Open the passed log file for reading and keep it open until object
        /// is no longer needed
        /// </summary>
        /// <param name="fileName"></param>
        public LogFileReader(String fileName)
        {
            //open file for reading
            logFile = new StreamReader(fileName);
        }

        public void PrintAliveMessage()=> Console.WriteLine("Still alive");

        /// <summary>
        /// make sure file is closed again
        /// </summary>
        ~LogFileReader()
        {

            Console.WriteLine($"Instance { GetHashCode() } of "
                            + $"class <{ GetType() }> is finalizing");

            // make sure file is closed, when object is garbage collected
            logFile.Dispose();
        }

    }
}
