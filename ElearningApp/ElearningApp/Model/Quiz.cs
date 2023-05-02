using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Model
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public List<Question> Questions { get; set; }

        public Quiz(int id, string category)
        {
            Id = id;
            Category = category;
            Questions = new List<Question>();
        }
    }
}
