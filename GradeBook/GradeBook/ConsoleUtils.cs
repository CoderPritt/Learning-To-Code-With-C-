using System;
using ConsoleTables;
using StudentLogic;

namespace GradeBook
{
    /// <summary>
    /// Console util methods used in the console for user interaction with applciation.
    /// </summary>
    public class ConsoleUtils
    {
        public string Version { get; set; }
        public DateTime date = DateTime.Now;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GradeBook.ConsoleUtils"/> class.
        /// </summary>
        /// <param name="ver">Ver.</param>
        public ConsoleUtils(string ver)
        {
            Version = ver;
        }

        /// <summary>
        /// Displays the opening message, version number, and today's date.
        /// </summary>
        public void OpeningMessage()
        {
            Console.WriteLine("################################\n"
            + "Welcome to the GradeBook Console\n"
            + "################################\n");
            Console.WriteLine("Version: " + Version);
            Console.WriteLine("Date:    " + date.ToString("yyyy MMMMM dd") + "\n");
        }

        /// <summary>
        /// Displaies the main menu.
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu\n" + "---------");
            Console.WriteLine("1.) Add Student");
            Console.WriteLine("2.) Add Grade");
            Console.WriteLine("3.) List All Students");
            Console.WriteLine("4.) Exit Application\n");
            Console.WriteLine("Please type an option then press ENTER\n");
        }

        /// <summary>
        /// Route menu selection to methods that handle given selection.
        /// </summary>
        public void MenuSelection()
        {
            int selection;
            int running = 0;

            while (running < 1)
            {
                try
                {
                    selection = int.Parse(Console.ReadLine());
                    switch (selection)
                    {
                        case 1:
                            Console.Clear();
                            AddStudent(this);
                            DisplayMainMenu();
                            break;
                        case 2:
                            Console.Clear();
                            AddGrade();
                            DisplayMainMenu();
                            break;
                        case 3:
                            Console.Clear();
                            ListStudents();
                            DisplayMainMenu();
                            break;
                        case 4:
                            running = 1;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Sorry, that selection was invalid. Please try again.\n");
                            DisplayMainMenu();
                            break;
                    }
                }
                catch
                {
                    DisplayMainMenu();
                }
            }
        }

        /// <summary>
        /// Allows user to add a student.
        /// </summary>
        public static void AddStudent(ConsoleUtils instance)
        {
            StudentGenerator sg = new StudentGenerator();

            Console.WriteLine("Please Enter First Name");
            string first = Console.ReadLine();

            Console.WriteLine("Please Enter Last Name");
            string last = Console.ReadLine();

            Console.WriteLine("Please Enter Grade");
            int grade = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAdded Student\n");
            Console.ForegroundColor = ConsoleColor.White;

            Student s = sg.Generate(first, last, grade);

            Students.StudentsList.Add(s);

        }

        /// <summary>
        /// Allows user to view a student.
        /// </summary>
        /// <returns><c>true</c>, if student was viewed, <c>false</c> otherwise.</returns>
        public void AddGrade()
        {
            // loads a student
            Console.WriteLine("Please Enter Student's ID:");
            string id = Console.ReadLine();

            Console.WriteLine("Add Grade percent as integer:");
            int grade = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAdded Grade\n");
            Console.ForegroundColor = ConsoleColor.White;

            Student student = Students.StudentsList.Find(s => s.StudentID == id);
            student.Grades.Add(grade);
        }

        /// <summary>
        /// Allows user to view list of all students.
        /// </summary>
        public void ListStudents()
        {
            var table = new ConsoleTable("Student Name", "Student ID");

            foreach (Student student in Students.StudentsList)
            {
                table.AddRow($"{student.FirstName} {student.LastName}", student.StudentID);
            }

            table.Write();
            Console.WriteLine("\n");
        }
    }
}