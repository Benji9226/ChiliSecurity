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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElearningApp.View.GuidePages
{
    /// <summary>
    /// Interaction logic for GuidePage.xaml
    /// </summary>
    public partial class GuidePage : Page
    {
        MainViewModel mvm;
        public GuidePage(string category)
        {
            InitializeComponent();
            mvm = new MainViewModel(category);
            DataContext = mvm;
            guideCategory.Content = category;
        }

        private void OpenSelectedPdfButton_Click(object sender, RoutedEventArgs e)
        {
            string guideToLoadName = mvm.SelectedGuideVM.GuideName;
            string guideToLoadCategory = mvm.SelectedGuideVM.Category;
            mvm.SelectedGuideVM.LoadGuide(guideToLoadName, guideToLoadCategory);
        }

        private void OpenQuizButton_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow quizWindow = new QuizWindow(guideCategory.Content.ToString());
            quizWindow.Show();
        }
    }
}
