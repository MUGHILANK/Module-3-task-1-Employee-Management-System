using Employee_Management_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Text;

namespace Employee_Management_System
{

    public class Employee
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime DateOfjoin { get; set; }

        public delegate void EmployeeAddedEventHandler(Employee emp);
        public static event EmployeeAddedEventHandler EmployeeAdded;

        public static async void saveTask(List<Employee> employees)
        {
            await Task.Run(() =>
            {
                string dicPath = "D:\\Module 3 Task\\Ems\\Employee Management System\\";
                string filePath = Path.Combine(dicPath, "EmployeeData.txt");

                try
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        foreach (var emp in employees)
                        {
                            string line = $"ID: {emp.Id}\nName:  {emp.Name}\nDepartment:  {emp.Department}\nSalary:    {emp.Salary}\nDOJ:  {emp.DateOfjoin}\n\n";
                            sw.WriteLine(line);

                        }
                        sw.Close();
                    }
                    Console.WriteLine("Employee data saved to file.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving file: " + ex.Message);
                }

            });
        }

        public static List<Employee> addData()
        {
            List<Employee> employees =new List<Employee>();

            string whileValue = "y";
            while (whileValue == "y")
            {
                Console.WriteLine("========== Adding Employee Details ==========");
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

                employees.Add(emp);
                EmployeeAdded?.Invoke(emp);
                Console.WriteLine("Employee added successfully!");

                Console.Write("Add More (Y/N): ");
                whileValue=Console.ReadLine().ToLower();

            }
            saveTask(employees);
            return employees;
           
        }
       
       public static void displayData(List<Employee> employees)
        {
            Console.WriteLine("========== Displaying Employee Details ==========");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID:{emp.Id} Name:{emp.Name} Department: {emp.Department} Salary: {emp.Salary} Date of join: {emp.DateOfjoin}");
            }
        }

        public static void filterDataUsingThreshold(List<Employee>employees)
        {
            Console.WriteLine("Enter the employees with salary above a threshold: ");
            double getThresholdValue = Convert.ToDouble(Console.ReadLine());

            var thresholdValue = employees.Where(a => a.Salary > getThresholdValue).ToList();

            Console.WriteLine($"\n======= Employee threhold salary =======");
            foreach (var emp in thresholdValue)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}");
            }

            Console.WriteLine("To update Salary: ");
            Console.Write("Enter Employee ID: ");
            int updateId = Convert.ToInt32(Console.ReadLine());
            var updateEmp = employees.FirstOrDefault(e => e.Id == updateId);

            if (updateEmp != null)
            {
                Console.Write("Enter new Salary: ");
                updateEmp.Salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Updated Salary for ID {updateId} is now {updateEmp.Salary}");
                saveTask(employees);
            }
            else
            {
                Console.WriteLine($"Employee with ID {updateId} not found.");
            }

        }

        public static void groupByDepartment(List<Employee> employees) 
        {
            var getGroupedBy = employees.GroupBy(e => e.Department);
            Console.WriteLine("\n====== Employees GroupBy ======");

            foreach (var value in getGroupedBy)
            {
                Console.WriteLine($"\nDepartment: {value.Key}");
                foreach (var emp in value)
                {
                    Console.WriteLine($"  ID: {emp.Id}, Name: {emp.Name}");

                }
            }
        }

        public static void sortByDoj(List<Employee> employees)
        {
                var sortBydoj = employees.OrderBy(e => e.DateOfjoin).ToList();
                Console.WriteLine("\n======= Employees Sorted by Joining Date =======");
                foreach (var emp in sortBydoj)
                {
                    Console.WriteLine($"Name: {emp.Name}, Joining Date: {emp.DateOfjoin.ToShortDateString()}");
                }

        }
    }
}


