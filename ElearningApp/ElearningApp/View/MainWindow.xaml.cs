using ElearningApp.View;
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
        GuideViewModel guideVM = new GuideViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileExplorerOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileExplorer = new OpenFileDialog();
            FileExplorer.ShowDialog();
            FilePath.Text = FileExplorer.FileName;
        }

        private void FileUploadButton_Click(object sender, RoutedEventArgs e)
        {
            guideVM.UploadGuide(GuideName.Text, FilePath.Text, GuideCategoryComboBox.Text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
    }
}
