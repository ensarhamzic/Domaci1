using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci1
{
    internal class Employee : IDisposable
    {
        public enum JobType
        {
            DEV,
            QA
        };
        private static int idCounter;
        private int id;
        private string name;
        private string surname;
        private int salary;
        private JobType jobType;

        public Employee(string name = "N/A", string surname = "N/A", int salary = 0, JobType jobType = JobType.DEV)
        {
            id = ++idCounter;
            this.jobType = jobType;
            this.name = name;
            this.surname = surname;
            this.salary = salary;
            MessageManager.OnMessageReceived += OnMessageReceived;
        }

        public void OnMessageReceived(Employee sender, string message)
        {
            bool messageReceived = false;
            if (id != sender.ID)
            {
                if (message.StartsWith("feature/"))
                {
                    message = message.Substring(8);
                    if (jobType == Employee.JobType.DEV)
                        messageReceived = true;
                }
                else if (message.StartsWith("testing/"))
                {
                    message = message.Substring(8);
                    if (jobType == Employee.JobType.QA)
                        messageReceived = true;
                }
                else
                    messageReceived = true;

                if(messageReceived)
                    Console.WriteLine($"Message to {name} {surname} {jobType} from {sender.Name}: {message} ");
            }
        }

        public void Dispose()
        {
            MessageManager.OnMessageReceived -= OnMessageReceived;
        }

        public JobType Job
        {
            get { return jobType; }
            set { jobType = value; }
        }

        public int ID
        {
            get { return id; }
        }

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value < 0)
                    salary = 0;
                else
                    salary = value;
            }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
