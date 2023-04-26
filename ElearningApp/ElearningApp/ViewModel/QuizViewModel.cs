using ElearningApp.Model;
using ElearningApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ElearningApp.ViewModel
{
    public class QuizViewModel
    {
        QuizRepository quizRepo = new QuizRepository();
        private Quiz quiz;
        public int Id { get; set; }
        public string Category { get; set; }
        public List<Question> Questions { get; set; }

        public QuizViewModel()
        {
        }
        public QuizViewModel(Quiz quiz)
        {
            this.quiz = quiz;
            Id = quiz.Id;
            Category = quiz.Category;
            Questions = quiz.Questions;
        }

        public Quiz GetQuiz(string category)
        {
            quiz = quizRepo.GetByCategory(category);
            return quiz;
        }
    }
}
