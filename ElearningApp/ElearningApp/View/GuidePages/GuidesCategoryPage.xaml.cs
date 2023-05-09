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

namespace ElearningApp.View.GuidePages
{
    /// <summary>
    /// Interaction logic for GuidesCategoryPage.xaml
    /// </summary>
    public partial class GuidesCategoryPage : Page
    {
        public GuidesCategoryPage()
        {
            InitializeComponent();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Button targetButton = (sender as Button);
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainPage.NavigationService.Navigate(new GuidePage(targetButton.Content.ToString()));
        }
    }
}
