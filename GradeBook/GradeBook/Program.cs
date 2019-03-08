using System;
using StudentLogic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {
            // instanciate the utility class and specify version
            ConsoleUtils utils = new ConsoleUtils("1.0.0");

            utils.OpeningMessage();
            utils.DisplayMainMenu();
            utils.MenuSelection();

            // test library
        }
    }
}
