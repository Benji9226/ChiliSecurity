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
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
        public string Category { get; set; }

        public Quiz(int id, string title, string category)
        {
            Id = id;
            Title = title;
            Questions = new List<Question>();
            Category = category;
        }
    }
}
