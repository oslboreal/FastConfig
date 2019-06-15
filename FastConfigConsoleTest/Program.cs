using FastConfig;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastConfigConsoleTest
{
    class Program
    {

        public Program()
        {

        }

        static void Main(string[] args)
        {
            ConsoleAppConfiguration consoleAppConfiguration = new ConsoleAppConfiguration();
            //consoleAppConfiguration.ProjectAuthor = "Marcos Vallejo";
            //consoleAppConfiguration.ProjectName = "Console Application - FastConfig test.";
            //consoleAppConfiguration.ProjectVer = "1.0.0v";
            //Manager.SaveConfiguration(consoleAppConfiguration);
            consoleAppConfiguration = Manager<ConsoleAppConfiguration>.LoadConfiguration(consoleAppConfiguration);


            Console.WriteLine("App started..");
            Console.WriteLine(consoleAppConfiguration.ToString());
            Console.WriteLine("App finished..");
            Console.ReadLine();
        }
    }
}
