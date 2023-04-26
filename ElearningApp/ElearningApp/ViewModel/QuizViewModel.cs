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
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
        public string Category { get; set; }

        public QuizViewModel()
        {
        }
        public QuizViewModel(Quiz quiz)
        {
            this.quiz = quiz;
            Id = quiz.Id;
            Title = quiz.Title;
            Questions = quiz.Questions;
            Category = quiz.Category;
        }

        public List<Quiz> GetQuiz(string category)
        {
            List<Quiz> quiz = quizRepo.GetQuizzesByCategory(category);
            return quiz;
        }
    }
}
