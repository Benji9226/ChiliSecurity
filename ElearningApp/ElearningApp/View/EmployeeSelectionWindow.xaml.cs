using ElearningApp.Model;
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
using System.Windows.Shapes;

namespace ElearningApp.View
{
    /// <summary>
    /// Interaction logic for EmployeeSelectionWindow.xaml
    /// </summary>
    public partial class EmployeeSelectionWindow : Window
    {
        private string quizCategory;
        EmployeeViewModel employeeVM = new EmployeeViewModel();
        public EmployeeSelectionWindow(string quizCategory)
        {
            InitializeComponent();
            this.quizCategory = quizCategory;
            ChooseEmployeeListBox.ItemsSource = employeeVM.LoadEmployees();
        }

        private void selectEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            employeeVM = new EmployeeViewModel((Employee)ChooseEmployeeListBox.SelectedItem);
            QuizWindow quizWindow = new QuizWindow(quizCategory, employeeVM);
            Close();
            quizWindow.Show();
        }
    }
}
