using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfjoin { get; set; }


        public void addData()
        {
            List<Employee> employee =new List<Employee>();

            string whileValue = "y";
            while (whileValue == "y")
            {
                Employee emp = new Employee();
                Console.Write("Enter Employee ID: ");
                emp.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the Name: ");
                emp.Name = Console.ReadLine();
                Console.Write("Enter Department: ");
                emp.Department = Console.ReadLine();
                Console.Write("Enter the Salary: ");
                emp.Salary =Convert.ToDouble( Console.ReadLine());
                Console.Write("Enter the Date of join: ");
                emp.DateOfjoin = DateTime.Parse(Console.ReadLine());

                Console.Write("Add More(Y/N): ");
                whileValue=Console.ReadLine().ToLower();

            }
        }
    }
}
