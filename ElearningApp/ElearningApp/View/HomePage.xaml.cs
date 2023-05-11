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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElearningApp.View.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        MainWindow mw;
        EmployeeViewModel employeeVM;
        public HomePage(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            mw.AdminPageTabControl.Visibility = Visibility.Hidden;
            mw.GuideTabControl.Visibility = Visibility.Hidden;
        }

        private void LeaderChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            LeaderChoiceButton.Visibility = Visibility.Hidden;
            EmployeeChoiceButton.Visibility = Visibility.Hidden;
            RoleChoiceLbl.Visibility = Visibility.Hidden;
            mw.AdminPageTabControl.Visibility = Visibility.Visible;
            mw.GuideTabControl.Visibility = Visibility.Visible;
        }

        private void EmployeeChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            employeeVM = new EmployeeViewModel();
            LeaderChoiceButton.Visibility = Visibility.Hidden;
            EmployeeChoiceButton.Visibility = Visibility.Hidden;
            RoleChoiceLbl.Visibility = Visibility.Hidden;
            mw.GuideTabControl.Visibility = Visibility.Visible;
            ChooseEmployeeListBox.Visibility = Visibility.Visible;
            ChooseEmployeeListBox.ItemsSource = employeeVM.LoadEmployees();
        }

        private void TakeNewRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            LeaderChoiceButton.Visibility = Visibility.Visible;
            EmployeeChoiceButton.Visibility = Visibility.Visible;
            RoleChoiceLbl.Visibility = Visibility.Visible;
            mw.AdminPageTabControl.Visibility = Visibility.Hidden;
            mw.GuideTabControl.Visibility = Visibility.Hidden;
        }
    }
}
