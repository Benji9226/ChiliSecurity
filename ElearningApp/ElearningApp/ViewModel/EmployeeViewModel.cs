using ElearningApp.Model;
using ElearningApp.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace ElearningApp.ViewModel
{
    public class EmployeeViewModel
    {
        EmployeeRepository employeeRepo = new EmployeeRepository();
        public Employee employee;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AmountGuidesCompleted { get; set; }

        public EmployeeViewModel()
        {
        }

        public EmployeeViewModel(Employee employee)
        {
            this.employee = employee;
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Email = employee.Email;
            AmountGuidesCompleted = employee.AmountGuidesCompleted;
        }

        public void UploadEmployee(string firstName, string lastName, string email, int amountGuidesCompleted)
        {
            Employee employeeToAdd = new Employee(firstName, lastName, email, amountGuidesCompleted);
            employeeRepo.AddEmployee(employeeToAdd);
        }

        public List<Employee> LoadEmployees()
        {
            return employeeRepo.GetAllEmployees();
        }

        public void UpdateEmployee()
        {
            employeeRepo.Update(employee, AmountGuidesCompleted);
        }
    }
}
