using ElearningApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElearningApp.View.AdminPages
{
    /// <summary>
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        EmployeeViewModel empViewModel = new EmployeeViewModel();

        private string firstName;
        private string lastName;
        private string email;
        private int amountGuideCompleted = 0;

        public EmployeePage()
        {
            InitializeComponent();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

            firstName = FirstNameTextBox.Text;
            lastName = LastNameTextBox.Text;
            email = EmailTextBox.Text;

            if (firstName == "" || lastName == "" || email == "")
            {
                MessageBox.Show("Please fill out all boxes");
            }
            else
            {
                empViewModel.UploadEmployee(firstName, lastName, email, amountGuideCompleted);
                MessageBox.Show("Employee has been added");

            }

        }
    }
}
