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
using System.Windows.Shapes;

namespace ElearningApp.View
{
    /// <summary>
    /// Interaction logic for ChiliWindow.xaml
    /// </summary>
    public partial class ChiliWindow : Window
    {
        MainViewModel mvm = new MainViewModel("Chili");
        public ChiliWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }

        private void OpenSelectedPdfButton_Click(object sender, RoutedEventArgs e)
        {
            string guideToLoadName = mvm.SelectedGuideVM.GuideName;
            string guideToLoadCategory = mvm.SelectedGuideVM.Category;
            mvm.SelectedGuideVM.LoadGuide(guideToLoadName, guideToLoadCategory);
        }

        private void openSelectedPdfQuizButton_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow quizWindow = new QuizWindow("Chili");
            quizWindow.Show();
        }
    }
}
