using System.Collections.Generic;
namespace Employee_Management_System 
{
    public class Program {
        public static void Main(string[] args){

            List<Employee> employees = Employee.addData();

            string runWhile = "y";
            Console.WriteLine("========== Employee Management System ==========");
            while (runWhile =="y") {
                Console.Write("1.To Display Full Data Table\n2.To Find Threshold Salary\nSelect the Option: ");
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

                    default:
                        Console.WriteLine("Select the Correct Answer: ");
                        break;


                }

                Console.WriteLine("Press See agian (Y/N): ");
                runWhile = Console.ReadLine();

            }
            
            


        }
    }

}