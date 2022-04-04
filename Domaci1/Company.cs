using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci1
{
    internal class Company
    {
        private List<Employee> employees;
        public List<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public Company()
        {
            employees = new List<Employee>();

            // Testing data
            //employees.Add(new Employee("Ensar", "Hamzic", 15000, Employee.JobType.DEV));
            //employees.Add(new Employee("Tarik", "Ibrahimovic", 25000, Employee.JobType.DEV));
            //employees.Add(new Employee("Adnan", "Crnovrsanin", 50000, Employee.JobType.QA));
            //employees.Add(new Employee("Ramiz", "Sabovic", 100000, Employee.JobType.QA));
            //employees.Add(new Employee("Mirza", "Salkovic", 75000, Employee.JobType.DEV));
        }
        
        public void AddEmployee(Employee.JobType jobType)
        {
            Console.WriteLine($"Enter {jobType} employee data:");
            string name;
            string surname;
            while(true)
            {
                Console.WriteLine("Name: ");
                name = Console.ReadLine();
                if (name.Length > 0)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid name!");
                    Console.ResetColor();
                }
            }
            while (true)
            {
                Console.WriteLine("Surname: ");
                surname = Console.ReadLine();
                if (surname.Length > 0)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid surname!");
                    Console.ResetColor();
                }
            }

            bool parsed;
            int salary;
            while(true)
            {
                Console.WriteLine("Salary: ");
                string salaryString = Console.ReadLine();
                parsed = int.TryParse(salaryString, out salary);
                if(parsed && salary > 0)
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Salary must be number, and must be greater than 0!");
                    Console.ResetColor();
                }   
            }
            employees.Add(new Employee(name, surname, salary, jobType));
            Console.WriteLine("Employee successfully added\n");
        }

        public void ShowEmployees()
        {
            foreach (Employee e in employees)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{e.ID}: {e.Name} {e.Surname} {e.Salary} | {e.Job}");
                Console.ResetColor();
            }
        }
        
        public void DeleteEmployee(Employee.JobType jobType)
        {
            int id;
            bool parsed;
            while (true)
            {
                Console.WriteLine($"Enter {jobType} employee ID that you want to delete (Enter 0 to go back)");
                string idString = Console.ReadLine();
                parsed = int.TryParse(idString, out id);
                if (parsed)
                {
                    if(id == 0)
                        break;
                    Employee foundEmp = employees.SingleOrDefault(e => e.ID == id);
                    if (foundEmp != null && foundEmp.Job == jobType)
                    {
                        employees.RemoveAll((e) => e.ID == id);
                        foundEmp.Dispose();
                        Console.WriteLine("Employee successfully deleted\n");
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Employee with that ID does not exist or is not {jobType}! Try again!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect ID Format! Try again!");
                    Console.ResetColor();
                }
            }
        }
        
        public void UpdateEmployee(Employee.JobType jobType)
        {
            int id;
            bool parsed;
            while (true)
            {
                Console.WriteLine($"Enter {jobType} employee ID that you want to update (Enter 0 to go back)");
                string idString = Console.ReadLine();
                parsed = int.TryParse(idString, out id);
                if (parsed)
                {
                    if (id == 0)
                        break;
                    Employee foundEmp = employees.SingleOrDefault(e => e.ID == id);
                    if (foundEmp != null && foundEmp.Job == jobType)
                    {
                        Console.WriteLine($"Enter new {jobType} employee data:");
                        Console.WriteLine($"Current name: {foundEmp.Name}");
                        Console.WriteLine("New name (leave blank if you do not want to change it):");
                        string name = Console.ReadLine();
                        Console.WriteLine($"Current surname: {foundEmp.Surname}");
                        Console.WriteLine("New surname (leave blank if you do not want to change it):");
                        string surname = Console.ReadLine();

                        bool parsed2;
                        bool salaryChanged = false;
                        int salary = 0;
                        while (true)
                        {
                            Console.WriteLine($"Current salary: {foundEmp.Salary}");
                            Console.WriteLine("New salary (leave blank if you do not want to change it):");
                            string salaryString = Console.ReadLine();
                            if (salaryString == "")
                            {
                                salaryChanged = false;
                                break;
                            }
                            parsed2 = int.TryParse(salaryString, out salary);
                            if (parsed2 && salary > 0)
                            {
                                salaryChanged = true;
                                break;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Salary must be number, and must be greater than 0!");
                                Console.ResetColor();
                            }
                        }
                        if(name != "")
                            foundEmp.Name = name;
                        if (surname != "")
                            foundEmp.Surname = surname;
                        if (salaryChanged)
                            foundEmp.Salary = salary;
                        Console.WriteLine("Employee successfully updated\n");
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Employee with that ID does not exist or is not {jobType}! Try again!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect ID Format! Try again!");
                    Console.ResetColor();
                }
            }
        }

        public int SendMessage()
        {
            int id;
            while (true)
            {
                Console.WriteLine("Enter id of employee that is sending a message (Enter 0 to go back):");
                bool parsed = int.TryParse(Console.ReadLine(), out id);
                if (parsed)
                {
                    if (id == 0)
                        return 0;
                    Employee foundEmp = employees.SingleOrDefault(e => e.ID == id);
                    if (foundEmp != null)
                    {
                        Console.WriteLine("Enter message:");
                        string message = Console.ReadLine();
                        MessageManager.SendMessage(foundEmp, message);
                        return 1;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Employee with that id is not found! Try again!");
                        Console.ResetColor();
                    }
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
