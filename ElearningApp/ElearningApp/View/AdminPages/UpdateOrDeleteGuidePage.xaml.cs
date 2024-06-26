﻿using ElearningApp.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElearningApp.View.AdminPages
{
    /// <summary>
    /// Interaction logic for UpdateOrDeleteGuidePage.xaml
    /// </summary>
    public partial class UpdateOrDeleteGuidePage : Page
    {
        MainViewModel mvm;
        public UpdateOrDeleteGuidePage()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GuideCategoryComboBox.SelectedItem != null)
            {
                string selectedItem = ((ComboBoxItem)GuideCategoryComboBox.SelectedItem).Content.ToString();
                mvm = new MainViewModel(selectedItem);
                DataContext = mvm;
                guidesInCategoryListBox.ItemsSource = mvm.GuidesVM;
            }
        }

        private void UpdateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void FileExplorerOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FileExplorer = new OpenFileDialog();
            FileExplorer.ShowDialog();
            FilePath.Text = FileExplorer.FileName;
        }

        private void updateThisGuideButton_Click(object sender, RoutedEventArgs e)
        {
            mvm.SelectedGuideVM.UpdateGuide(mvm.SelectedGuideVM.guide, GuideName.Text, FilePath.Text, updateOrDeleteGuideCategoryComboBox.Text);
            MessageBox.Show("Guide has been updated.");
        }

        private void deleteGuideButton_Click(object sender, RoutedEventArgs e)
        {
            mvm.SelectedGuideVM.DeleteGuide(mvm.SelectedGuideVM.guide);
            MessageBox.Show("Guide has been deleted.");
        }
    }
}
