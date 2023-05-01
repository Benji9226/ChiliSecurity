using ElearningApp.View;
using ElearningApp.View.AdminWindows;
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
        }

        private void ChiliButton_Click(object sender, RoutedEventArgs e)
        {
            GuideWindow guideWindow = new GuideWindow(ChiliButton.Content.ToString());
            guideWindow.Show();
        }

        private void EWIIButton_Click(object sender, RoutedEventArgs e)
        {
            GuideWindow guideWindow = new GuideWindow(EWIIButton.Content.ToString());
            guideWindow.Show();
        }

        private void EnergiFynButton_Click(object sender, RoutedEventArgs e)
        {
            GuideWindow guideWindow = new GuideWindow(EnergiFynButton.Content.ToString());
            guideWindow.Show();
        }

        private void FlatPlayButton_Click(object sender, RoutedEventArgs e)
        {
            GuideWindow guideWindow = new GuideWindow(FlatPayButton.Content.ToString());
            guideWindow.Show();
        }

        private void uploadGuideButton_Click(object sender, RoutedEventArgs e)
        {
            UploadGuideWindow uploadGuideWindow = new UploadGuideWindow();
            uploadGuideWindow.Show();
        }
        private void updateOrDeleteGuideButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateOrDeleteGuideWindow updateGuideWindow = new UpdateOrDeleteGuideWindow();
            updateGuideWindow.Show();
        }
    }
}
