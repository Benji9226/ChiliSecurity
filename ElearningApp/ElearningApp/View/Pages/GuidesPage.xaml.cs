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
    /// Interaction logic for GuidesPage.xaml
    /// </summary>
    public partial class GuidesPage : Page
    {
        public GuidesPage()
        {
            InitializeComponent();
        }
        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Button targetButton = (sender as Button);
            GuideWindow guideWindow = new GuideWindow(targetButton.Content.ToString());
            guideWindow.Show();
        }
    }
}
