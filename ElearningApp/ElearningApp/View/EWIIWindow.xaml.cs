﻿using ElearningApp.ViewModel;
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
    /// Interaction logic for EWIIWindow.xaml
    /// </summary>
    public partial class EWIIWindow : Window
    {
        MainViewModel mvm = new MainViewModel("EWII");
        public EWIIWindow()
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
    }
}
