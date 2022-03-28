using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewCSharp.oops;
namespace ReviewCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //goi class

            EmployeeList lst;
            lst = new EmployeeList();
            List<Employee> employees= lst.getAllEmployees();
            //FOR
            for (int i=0;i<employees.Count; i++) {

                Employee emp = employees[i];
                Console.WriteLine("EmployeeId: {0} EmployeeName {1}",
                                   emp.EmployeeId, emp.EmployeeName);
            }


            //FOREACH
            foreach (Employee emp in employees) {

                Console.WriteLine("EmployeeId: {0} EmployeeName {1}",
                                   emp.EmployeeId, emp.EmployeeName);
            }

            Console.ReadKey();
        }



        }
    }
}
