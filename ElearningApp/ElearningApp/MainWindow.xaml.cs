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
        GuideController guideController = new GuideController();
        GuideRepository guideRepo = new GuideRepository();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileExplorerOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileExplorer = new OpenFileDialog();
            FileExplorer.ShowDialog();
            FileLocation.Text = FileExplorer.FileName;
        }

        private void FileUploadButton_Click(object sender, RoutedEventArgs e)
        {
            if (GuideName.Text != "" && FileLocation.Text != "")
            {
                guideRepo.SaveFile(GuideName.Text, FileLocation.Text);
                MessageBox.Show("Guiden er nu uploaded.");
            }
            else if (GuideName.Text == "")
                MessageBox.Show("FEJL: Guide ikke navngivet");
            else
                MessageBox.Show("FEJL: Ingen fil valgt");
        }

        private void GuideOneButton_Click(object sender, RoutedEventArgs e)
        {
            string guideName = GuideOneButton.Content.ToString();
            guideController.LoadGuide(guideName);
        }
    }
}
