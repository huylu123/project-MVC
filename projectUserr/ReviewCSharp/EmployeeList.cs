using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewCSharp.oops;

namespace ReviewCSharp
{
    class EmployeeList
    {

        // methods
        // <quyen truy xuat>  < return type> methodname() {}
        public List<Employee> getAllEmployees() {
            List<Employee> lst = new List<Employee>() {

                new Employee(){ EmployeeId = 1,
                                EmployeeName ="Tran Van A",
                                Address = "123 NT"
                              },
                new Employee(){ EmployeeId = 2,
                                EmployeeName ="Tran B",
                                Address = "123/34 TT"
                              }
            };


            return lst;
        }

    }
}
