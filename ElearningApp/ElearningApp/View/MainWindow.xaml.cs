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
using ElearningApp.Model;
using ElearningApp.Persistence;

namespace ElearningApp
{ 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeViewModel employeeVM = new EmployeeViewModel();
        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new HomePage(this);

        }
        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new HomePage(this);
        }

        private void GuidesPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new GuidesCategoryPage();
        }
        private void AdminPage_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new AdminPage();
        }

       

      
      


    }
}
