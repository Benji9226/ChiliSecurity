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

namespace ElearningApp.ViewModel
{
    public class GuideController
    {
        GuideRepository guideRepo = new GuideRepository();

        public void LoadGuide(Guide guide)
        {
            if (!File.Exists($"{guide.GuideName}.pdf")) { CreateGuideFile(guide.GuideName); }
            Process.Start(new ProcessStartInfo($"{guide.GuideName}.pdf") { UseShellExecute = true });
        }

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

        private void CreateGuideFile(string guideName)
        {
            byte[] data = guideRepo.GetByName(guideName).LearningMaterial;
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite($"{guideName}.pdf")))
            {
                writer.Write(data);
            }
        }
    }
}
