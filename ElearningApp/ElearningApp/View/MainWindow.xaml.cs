using ElearningApp.View;
using ElearningApp.View.Pages;
using ElearningApp.View.GuidePages;
using ElearningApp.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
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
using Path = System.IO.Path;

namespace ElearningApp
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new HomePage();
            NewRoleChoiceLbl.Visibility = Visibility.Hidden;
            TakeNewRoleBtn.Visibility = Visibility.Hidden; 
        }
        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new HomePage();
            NewRoleChoiceLbl.Visibility = Visibility.Visible;
            Welcome_Label.Visibility = Visibility.Visible;
            TakeNewRoleBtn.Visibility= Visibility.Visible;
        }

        private void GuidesPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new GuidesCategoryPage();
            Welcome_Label.Visibility = Visibility.Hidden;
        }
        private void AdminPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new AdminPage();
            Welcome_Label.Visibility= Visibility.Hidden;
        }

        private void LeaderChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPageTabControle.Visibility = Visibility.Visible;
            LeaderChoiceButton.Visibility = Visibility.Hidden;
            EmployeeChoiceButton.Visibility = Visibility.Hidden;
            RoleChoiceLbl.Visibility = Visibility.Hidden;
        }

        private void EmployeeChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            LeaderChoiceButton.Visibility = Visibility.Hidden;
            EmployeeChoiceButton.Visibility = Visibility.Hidden;
            RoleChoiceLbl.Visibility = Visibility.Hidden;
            AdminPageTabControle.Visibility= Visibility.Hidden;
        }

        private void TakeNewRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            LeaderChoiceButton.Visibility = Visibility.Visible;
            EmployeeChoiceButton.Visibility = Visibility.Visible;
            TakeNewRoleBtn.Visibility = Visibility.Hidden;
            RoleChoiceLbl.Visibility = Visibility.Visible;
            NewRoleChoiceLbl.Visibility = Visibility.Hidden;
        }
    }
}
