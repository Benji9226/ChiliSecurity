using ElearningApp.Model;
using ElearningApp.Persistence;
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
        GuideViewModel guideViewModel = new GuideViewModel();
        GuideRepository guideRepo = new GuideRepository();
        QuizWindow qw = new QuizWindow();

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
            guideViewModel.UploadGuide(GuideName.Text, FilePath.Text);
        }

        private void GuideOneButton_Click(object sender, RoutedEventArgs e)
        {
           // guideViewModel.LoadGuide(guideRepo.GetByName("Chili Installation"));

        }

        private void Quiz_Click(object sender, RoutedEventArgs e)
        {
            qw.ShowDialog();
        }
    }
}
