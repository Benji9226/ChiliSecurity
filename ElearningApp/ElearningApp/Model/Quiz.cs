using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Model
{
    public class Quiz
    {
        public  string Description { get; set; }

        public int Result { get; set; }

        public string GuideName { get; set; }

        public string[] Answers { get; set; }

    }
}
