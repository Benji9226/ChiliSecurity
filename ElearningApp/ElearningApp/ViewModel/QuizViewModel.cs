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
        string Answer1;
        string Answer2;
        string Answer3;
        string Answer4;
        List<string> Descriptions = new List<string>();
        List<string> GuideNames = new List<string>();
        List<string> TempAnswer = new List<string>();
        string[,] answersArray = new string[100, 4];


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
                   GuideNames.Add(GuideName);
                   
                   for(int i = 0; GuideNames.Count > i; i++)
                   {
                        Description = quiz.Description;
                        Descriptions.Add(Description);

                        for (int j = 0; Descriptions.Count > j; j++)
                        {


                            Answer1 = quiz.Answers[0];
                            Answer2 = quiz.Answers[1];
                            Answer3 = quiz.Answers[2];
                            Answer4 = quiz.Answers[3];

                            answersArray[j, 0] = Answer1;
                            answersArray[j, 1] = Answer2;
                            answersArray[j, 2] = Answer3;
                            answersArray[j, 3] = Answer4;

                            //TempAnswer.Add(Answer1);
                            //TempAnswer.Add(Answer2);
                            //TempAnswer.Add(Answer3);
                            //TempAnswer.Add(Answer4);

                            Result = quiz.Result;
                        }
                    }

                   
                
                }
            }
        }
    }
}
