using ElearningApp.Model;
using ElearningApp.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
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
    public class GuideViewModel
    {
        GuideRepository guideRepo = new GuideRepository();
        private Guide guide;
        public string GuideName { get; set; }
        public byte[] LearningMaterial { get; set; }
        public string Category { get; set; }

        public GuideViewModel()
        {
        }

        public GuideViewModel(Guide guide)
        {
            this.guide = guide;
            GuideName = guide.GuideName;
            LearningMaterial = guide.LearningMaterial;
            Category = guide.Category;
        }

        public void LoadGuide(string guideToLoad)
        {
            Guide guide = guideRepo.GetByName(guideToLoad);
            if (!File.Exists($"{guide.GuideName}.pdf")) { CreateGuideFile(guide.GuideName); }
            ShowGuide(guide);
        }

        public void UploadGuide(string guideName, string filePath, string category)
        {
            if (guideName != "" && filePath != "" && category != "")
            {
                foreach (Guide guide in guideRepo.GetAll())
                {
                    if (guideName == guide.GuideName && category == guide.Category)
                    {
                        MessageBox.Show("Navnet eksistere allerede.");
                    }
                    else 
                    {
                        using (Stream stream = File.OpenRead(filePath))
                        {
                            byte[] byteArray = new byte[stream.Length];
                            stream.Read(byteArray, 0, byteArray.Length);
                            Guide guideToAdd = new Guide(guideName, byteArray, category);
                            guideRepo.Add(guideToAdd);
                        }
                        MessageBox.Show("Guiden er nu uploaded.");
                    }
                }
            }
            else if (guideName == "")
                MessageBox.Show("FEJL: Guide ikke navngivet");
            else if (filePath == "")
                MessageBox.Show("FEJL: Ingen fil valgt");
            else
                MessageBox.Show("FEJL: Ingen kategori valgt");
        }

        public Guide GetGuide(string guideToGet)
        {
            return guideRepo.GetByName(guideToGet);
        }

        private void CreateGuideFile(string guideName)
        {
            byte[] data = guideRepo.GetByName(guideName).LearningMaterial;
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite($"{guideName}.pdf")))
            {
                writer.Write(data);
            }
        }

        private void ShowGuide(Guide guideToShow)
        {
            Process.Start(new ProcessStartInfo($"{guideToShow.GuideName}.pdf") { UseShellExecute = true });
        }
    }
}
