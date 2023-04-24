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

        public void LoadGuide(string guideToLoad)
        {
            Guide guide = guideRepo.GetByName(guideToLoad);
            if (!File.Exists($"{guide.GuideName}.pdf")) { CreateGuideFile(guide.GuideName); }
            ShowGuide(guide);
        }

        public void UploadGuide(string guideName, string filePath)
        {
            if (guideName != "" && filePath != "")
            {
                foreach (Guide guide in guideRepo.GetAll())
                {
                    if (guideName == guide.GuideName)
                    {
                        MessageBox.Show("Navnet eksistere allerede");
                    }
                    else 
                    {
                        using (Stream stream = File.OpenRead(filePath))
                        {
                            byte[] byteArray = new byte[stream.Length];
                            stream.Read(byteArray, 0, byteArray.Length);

                            Guide guideToAdd = new Guide(guideName, byteArray);
                            guideRepo.Add(guideToAdd);
                        }
                        MessageBox.Show("Guiden er nu uploaded.");
                    }
                        
                }
            }
            else if (guideName == "")
                MessageBox.Show("FEJL: Guide ikke navngivet");
            else
                MessageBox.Show("FEJL: Ingen fil valgt");
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

        private void ShowGuide(Guide guide)
        {
            Process.Start(new ProcessStartInfo($"{guide.GuideName}.pdf") { UseShellExecute = true });
        }
    }
}
