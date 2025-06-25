using System.Collections.Generic;
namespace Employee_Management_System 
{
    public class Program {
        public static void Main(string[] args){

            Employee.EmployeeAdded += (emp) =>
            {
                Console.WriteLine($"\n[Event] New employee added: {emp.Name} (ID: {emp.Id})");
            };

            List<Employee> employees = Employee.addData();

            string runWhile = "y";
            Console.WriteLine("========== Employee Management System ==========");
            while (runWhile =="y") {
                Console.Write("1.To Display Full Data Table\n2.To Find Threshold Salary\n3.To grp By Department\n4.To sort By Date of join\nSelect the Option: ");
                int switchData = Convert.ToInt32(Console.ReadLine());

                switch (switchData)
                {
                    //case 1:
                    //    //List<Employee> employees = Employee.addData();
                    //    break;

                    case 1:
                        Employee.displayData(employees);
                        break;

                    case 2:
                        Employee.filterDataUsingThreshold(employees);
                        break;

                    case 3:
                        Employee.groupByDepartment(employees);
                        break;

                    case 4:
                        Employee.sortByDoj(employees);
                        break; 

                    default:
                        Console.WriteLine("Select the Correct Answer: ");
                        break;
                }

                Employee.saveTask(employees);


                Console.WriteLine("Press See agian (Y/N): ");
                runWhile = Console.ReadLine();

                

            }
            
            


        }
    }

}