using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Model
{
    public class Question
    {
        public string Text { get; set; }
        public string[] PossibleAnswers { get; set; }
        public string CorrectAnswer { get; set; }
        public string Category { get; set; }

        public Question(string text, string[] possibleAnswers, string correctAnswerIndex, string category)
        {
            Text = text;
            PossibleAnswers = possibleAnswers;
            CorrectAnswer = correctAnswerIndex;
            Category = category;
        }
    }
}
