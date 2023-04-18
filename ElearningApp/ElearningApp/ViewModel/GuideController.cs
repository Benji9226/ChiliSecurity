using ElearningApp.Model;
using ElearningApp.Persistence;
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

namespace ElearningApp.ViewModel
{
    public class GuideController
    {
        GuideRepository guideRepo = new GuideRepository();

        /// <summary>
        /// Method for loading a selected guide so it can be opened. If a file is not yet created, the method
        /// calls a helping method to create a guide file in the system so that it can be representet as intended.
        /// </summary>
        /// <param name="guide"></param>
        public void LoadGuide(Guide guide)
        {
            if (!File.Exists($"{guide.GuideName}.pdf")) { CreateGuideFile(guide.GuideName); }
            ShowGuide(guide);
        }

        /// <summary>
        /// Method to Upload a guide to the system with a guide name and the path of the file to be uploaded.
        /// </summary>
        /// <param name="guideName"></param>
        /// <param name="filePath"></param>
        public void UploadGuide(string guideName, string filePath)
        {
            if (guideName != "" && filePath != "")
            {
                guideRepo.SaveFile(guideName, filePath);
                MessageBox.Show("Guiden er nu uploaded.");
            }
            else if (guideName == "")
                MessageBox.Show("FEJL: Guide ikke navngivet");
            else
                MessageBox.Show("FEJL: Ingen fil valgt");
        }

        /// <summary>
        /// Helping method to Create a PDF guide file if one does not exist in the system.
        /// </summary>
        /// <param name="guideName"></param>
        private void CreateGuideFile(string guideName)
        {
            byte[] data = guideRepo.GetByName(guideName).LearningMaterial;
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite($"{guideName}.pdf")))
            {
                writer.Write(data);
            }
        }

        /// <summary>
        /// Helping method to run the process which opens up the PDF file for the user to read.
        /// </summary>
        /// <param name="guide"></param>
        private void ShowGuide(Guide guide)
        {
            Process.Start(new ProcessStartInfo($"{guide.GuideName}.pdf") { UseShellExecute = true });
        }
    }
}
