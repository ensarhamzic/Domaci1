using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci1
{
    internal class Program
    {
        static Company company = new Company();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to ITCompany admin and messaging system.");
            Console.ResetColor();
            ShowStartDialog();
            Console.ReadKey();
        }

        public static void ShowStartDialog()
        {
            int userChoice;
            bool parsed;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n1. Create, Update or Delete employee data");
                Console.WriteLine("2. Send message to employees");
                Console.WriteLine("0. Exit App\n");
                Console.ResetColor();

                parsed = int.TryParse(Console.ReadLine(), out userChoice);
                if (parsed == true && userChoice >= 0 && userChoice <= 2)
                {
                    switch(userChoice)
                    {
                        case 0:
                            Console.WriteLine("Press any key to exit...");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        case 1:
                            ShowCRUDDialog();
                            break;
                        case 2:
                            ShowMessageDialog();
                            break;
                    }
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input error! Try again!");
                    Console.ResetColor();
                }
            }
        }

        private static void ShowMessageDialog()
        {
            int res = company.SendMessage();
            if (res == 0)
                ShowStartDialog();
            else
                ShowMessageDialog();
        }

        public static int ShowCRUDDialog()
        {
            int userChoice;
            bool parsed;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n1. Create new Developer Employee");
                Console.WriteLine("2. Update Developer Employee");
                Console.WriteLine("3. Delete Developer Employee");
                Console.WriteLine("4. Create new QA Employee");
                Console.WriteLine("5. Update QA Employee");
                Console.WriteLine("6. Delete QA Employee");
                Console.WriteLine("7. Show All Employees");
                Console.WriteLine("0. Go Back\n");
                Console.ResetColor();

                parsed = int.TryParse(Console.ReadLine(), out userChoice);
                if (parsed == true && userChoice >= 0 && userChoice <= 7)
                {
                    switch(userChoice)
                    {
                        case 0:
                            ShowStartDialog();
                            break;
                        case 1:
                            company.AddEmployee(Employee.JobType.DEV);
                            break;
                        case 2:
                            company.UpdateEmployee(Employee.JobType.DEV);
                            break;
                        case 3:
                            company.DeleteEmployee(Employee.JobType.DEV);
                            break;
                        case 4:
                            company.AddEmployee(Employee.JobType.QA);
                            break;
                        case 5:
                            company.UpdateEmployee(Employee.JobType.QA);
                            break;
                        case 6:
                            company.DeleteEmployee(Employee.JobType.QA);
                            break;
                        case 7:
                            company.ShowEmployees();
                            break;
                    }
                    ShowCRUDDialog();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input error! Try again!");
                    Console.ResetColor();
                }
            }
        }
    }
}
