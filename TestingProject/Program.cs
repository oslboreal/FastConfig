using System;
using System.Dynamic;
using FastConfig;

namespace TestingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            SecondTestingClass secondTestingClass = new SecondTestingClass();

            // 0.
            var result = Manager<SecondTestingClass>.UpdateConfiguration(secondTestingClass, ActionType.LoadConfiguration);

            // 1.
            secondTestingClass.PropDos = 1;
            secondTestingClass.propUno = 1;
            result = Manager<SecondTestingClass>.UpdateConfiguration(secondTestingClass, ActionType.SaveConfiguration);
            Console.WriteLine(result.propUno);
            Console.WriteLine(result.PropDos);

            secondTestingClass.PropDos = 2;
            secondTestingClass.propUno = 2;
            result = Manager<SecondTestingClass>.UpdateConfiguration(secondTestingClass, ActionType.SaveConfiguration);
            Console.WriteLine(result.propUno);
            Console.WriteLine(result.PropDos);

            result = Manager<SecondTestingClass>.UpdateConfiguration(secondTestingClass, ActionType.LoadConfiguration);


            Console.ReadLine();
        }
    }
}
