using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Model
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int AmountGuidesCompleted { get; set; }

        public Employee(string firstName, string lastName, string email, int amountGuidesCompleted)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AmountGuidesCompleted = amountGuidesCompleted;
        }
    }
}
