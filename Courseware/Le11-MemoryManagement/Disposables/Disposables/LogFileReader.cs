using System;
using System.IO;

namespace Disposables
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
            try
            {
                logFile = new StreamReader(fileName);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintAliveMessage()=> Console.WriteLine("Still alive");

        /// <summary>
        /// make sure file is closed again
        /// </summary>
        ~LogFileReader()
        {
            DisposableApp.GlobalReference = this;

            Console.WriteLine("Instance {0} of class <{1}> is finalizing", GetHashCode(), GetType());

            // make sure file is closed, when object is garbage collected
            if(logFile != null)
                try
                {
                    logFile.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception when closing file");
                }

            logFile = null;
        }

    }
}
