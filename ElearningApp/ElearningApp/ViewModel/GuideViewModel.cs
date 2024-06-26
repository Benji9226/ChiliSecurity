﻿using ElearningApp.Model;
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
        public Guide guide;
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

        public void LoadGuide(string guideToLoadName, string guideToLoadCategory)
        {
            Guide guide = guideRepo.GetByNameAndCategory(guideToLoadName, guideToLoadCategory);
            if (!File.Exists($"Guides\\{guide.Category}\\{guide.GuideName}.pdf")) 
            { 
                CreateGuideFile(guide); 
            }
            ShowGuide(guide);
        }

        public void UploadGuide(string guideName, string filePath, string category)
        {
            bool nameAlreadyExist = false;
            string mSBox = "";

            if (guideName != "" && filePath != "" && category != "")
            {
                List<Guide> guideList = guideRepo.GetAll();
                foreach (Guide guide in guideList)
                {
                    if (guideName == guide.GuideName && category == guide.Category)
                    {
                        mSBox = "The name already exist.";
                        nameAlreadyExist = true;
                        break;
                    }
                }

                if (nameAlreadyExist == false)
                {
                    using (Stream stream = File.OpenRead(filePath))
                    {
                        byte[] byteArray = new byte[stream.Length];
                        stream.Read(byteArray, 0, byteArray.Length);
                        Guide guideToAdd = new Guide(guideName, byteArray, category);
                        guideRepo.Add(guideToAdd);
                    }
                    mSBox = "Guide is now uploaded.";
                }
                MessageBox.Show(mSBox);
            }

            else
            {
                MessageBox.Show("Please fill out all boxes");
            }
        }

        public void UpdateGuide(Guide guide, string newGuideName, string filePath, string newGuideCategory)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] byteArray = new byte[stream.Length];
                stream.Read(byteArray, 0, byteArray.Length);
                guideRepo.Update(guide, newGuideName, byteArray, newGuideCategory);
            }
        }

        public void DeleteGuide(Guide guide)
        {
            guideRepo.Delete(guide);
        }

        private void CreateGuideFile(Guide guide)
        {
            Directory.CreateDirectory("Guides").CreateSubdirectory(guide.Category);
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite($"Guides\\{guide.Category}\\{guide.GuideName}.pdf")))
            {
                writer.Write(guide.LearningMaterial);
            }
        }

        private void ShowGuide(Guide guideToShow)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Guides\\{guideToShow.Category}\\{guideToShow.GuideName}.pdf");
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}
