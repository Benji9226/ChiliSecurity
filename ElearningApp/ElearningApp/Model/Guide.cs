using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Model
{
    public class Guide
    {
        public string GuideName { get; set; }
        public byte[] LearningMaterial { get; set; }
        public string Category { get; set; }

        public Guide(string guideName, byte[] learningMaterial, string category)
        {
            GuideName = guideName;
            LearningMaterial = learningMaterial;
            Category = category;
        }
    }
}
