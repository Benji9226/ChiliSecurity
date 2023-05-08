using ElearningApp.Model;
using ElearningApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.ViewModel
{
    public class EmployeeViewModel
    {

        EmployeeRepository employeeRepo = new EmployeeRepository();
        
        public void UploadEmployee(string firstName, string lastName, string email, int amountGuidesCompleted)
        {
            Employee employeeToAdd = new Employee(firstName, lastName, email, amountGuidesCompleted);
            employeeRepo.AddEmployee(employeeToAdd);
        }

    }
}
