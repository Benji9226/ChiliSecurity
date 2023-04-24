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
    /// Interaction logic for FlatPayWindow.xaml
    /// </summary>
    public partial class FlatPayWindow : Window
    {
        MainViewModel mvm = new MainViewModel("FlatPay");
        public FlatPayWindow()
        {
            InitializeComponent();
            DataContext = mvm;
        }

        private void openSelectedPdfButton_Click(object sender, RoutedEventArgs e)
        {
            string guideToLoadName = mvm.SelectedGuideVM.GuideName;
            string guideToLoadCategory = mvm.SelectedGuideVM.Category;
            mvm.SelectedGuideVM.LoadGuide(guideToLoadName, guideToLoadCategory);
        }
    }
}
