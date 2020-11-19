using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WindowsAsync
{
    /// <summary>
    /// As simple window with a button a two text fields
    /// </summary>
    internal class TestUi : Window
    {
        private Button button = new Button {Content = "Run test", Width = 100, Height = 30, Margin = new Thickness(50)};
        private TextBlock output = new TextBlock();

        public TestUi()
        {
            Width = 400;
            Height = 300;

            button.Click += (sender, args) => UpdateUi();

            var panel = new StackPanel();
            panel.Children.Add(button);
            panel.Children.Add(output);

            Content = panel;
        }

        /// <summary>
        /// Updates the UI
        /// </summary>
        private void UpdateUi()
        {
            // Does some long running task, this blocks the display of the current time


            // TODO: make this call asynchronous
            DisplayNumberOfPrimes();

            // shows the current time
            DisplayCurrentTime();

            // TODO: make this call asynchronous
            int hashCodes = SomeFileIO();
            output.Text += "The hash code is " + hashCodes + Environment.NewLine;
        }

        /// <summary>
        /// calculates the prima in five different ranges and displays them in the GUI
        /// </summary>
        private void DisplayNumberOfPrimes()
        {
            for (int i = 1; i < 5; i++)
                output.Text += string.Format("There are {0} primes between {1} and {2}\n",
                    CountPrimes(i * 100000, 1000000), i*100000, (i+1) * 100000-1);
        }

        /// <summary>
        /// Prints the current time into the primes-Textblock (GUI)
        /// </summary>
        private void DisplayCurrentTime()
        {
            output.Text += DateTime.Now + Environment.NewLine;
        }

       /// <summary>
       /// calculates the number of primes in the specified range
       /// </summary>
       /// <param name="start">start number</param>
       /// <param name="count">range value, beginning from start</param>
       /// <returns></returns>
        private int CountPrimes(int start, int count)
        {
            return Enumerable.Range(start, count).Count(n => Enumerable.Range(2, (int) Math.Sqrt(n) - 1).All(i => n%i > 0));
        }

        /// <summary>
        /// Perform some file I/O
        /// </summary>
        /// <returns></returns>
        private int SomeFileIO()
        {
            string filename = "test.txt";
            var sb = new StringBuilder();
            using (var f = new StreamWriter(File.Open(filename, FileMode.Create)))
            {
                for (int i = 0; i < 15000; i++)
                {
                    sb.Append("test" + i);
                    f.WriteLine(sb.ToString());
                }
                f.Flush();
            }

            int result = 0;
            using (var f = File.OpenText(filename))
                for (int i = 0; i < 15000; i++)
                    result ^= f.ReadLine().GetHashCode();

            File.Delete(filename);

            return result;
        }
    }
}