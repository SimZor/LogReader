using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = args[0];
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            if (filepath == "")
            {
                Console.WriteLine("You must input a filepath.");
            }
            else
            {
                try
                {
                    // Create new StreamReader object for reading the log file
                    // with using statement to make sure that it disposes
                    // later on.
                    using (StreamReader streamReader = new StreamReader(@"E:\Development\test.rpt"))
                    {
                        string thisLine = "";
                        do
                        {
                            thisLine = streamReader.ReadLine();

                            // Print the first 8 letters with specific text color. This is
                            // to represent the date in a different color so it is easily
                            // distinguishable.
                            if (thisLine.StartsWith(""))
                                for (int i = 0; i < 8; i++)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write(thisLine[i]);
                                }

                            // Reset foreground color
                            Console.ForegroundColor = ConsoleColor.White;
                            
                            // Write out rest of the characters in line
                            for (int i = 8; i < (thisLine.Length - 8); i++)
                            {
                                Dictionary<string, ConsoleColor> consoleColors = new Dictionary<string, ConsoleColor>();
                                consoleColors.Add("DEBUG", ConsoleColor.DarkCyan);
                                consoleColors.Add("INFO", ConsoleColor.Blue);
                                consoleColors.Add("WARNING", ConsoleColor.DarkRed);
                                consoleColors.Add("ERROR", ConsoleColor.DarkRed);
                                consoleColors.Add("CRITICAL", ConsoleColor.Red);

                                foreach (KeyValuePair<string, ConsoleColor> entry in consoleColors)
                                {
                                    if (thisLine.ToUpper().Contains(entry.Key))
                                    {
                                        Console.ForegroundColor = entry.Value;
                                    }
                                }

                                Console.Write(thisLine[i]);
                            }

                            // New line
                            Console.Write("\n");
                        }
                        while (thisLine != "");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read");
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }

            // Ensure that the user presses
            // any key before the program closes.
            Console.ReadKey();
        }
    }
}
