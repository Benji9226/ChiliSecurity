using ElearningApp.Model;
using ElearningApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.ViewModel
{
    public class QuizViewModel
    {


        QuizRepo quizRepo = new QuizRepo();
        string Description;
        int Result;
        string GuideName;
        string[] Answers;


        public QuizViewModel(string guideName)
        {
            GuideName = guideName;

        }


        public void DisplayQuiz()
        {
            List<Quiz> quizList = new List<Quiz>();

            quizList = quizRepo.LoadQuizDescriptions();


            foreach (Quiz quiz in quizList)
            {
                if(GuideName == quiz.GuideName)
                {
                   Description = quiz.Description;
                   Result = quiz.Result;
                   
                    if(Description)
                
                    
                
                }
            }
        }
    }
}
