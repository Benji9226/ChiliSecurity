using ElearningApp.Model;
using ElearningApp.ViewModel;
using Microsoft.Win32;
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
    /// Interaction logic for UploadGuideWindow.xaml
    /// </summary>
    public partial class UploadGuideWindow : Window
    {
        public MainWindow mW { get; set; }
        GuideViewModel guideVM = new GuideViewModel();

        public UploadGuideWindow()
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
    }
}
