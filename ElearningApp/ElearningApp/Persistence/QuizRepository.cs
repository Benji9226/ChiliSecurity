using ElearningApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Persistence
{
    public class QuizRepository
    {
        private List<Quiz> quizzes;
        string connectionString = "Server=10.56.8.36; database=P3_DB_2023_03; user id=P3_PROJECT_USER_03; password=OPENDB_03; TrustServerCertificate=true;";

        public QuizRepository()
        {
            quizzes = new List<Quiz>();
            quizzes = GetAll();
        }

        public List<Quiz> GetAll()
        {
            quizzes.AddRange(GetQuizzesByCategory("Chili"));
            quizzes.AddRange(GetQuizzesByCategory("EWII"));
            quizzes.AddRange(GetQuizzesByCategory("EnergiFyn"));
            quizzes.AddRange(GetQuizzesByCategory("FlatPay"));
            return quizzes;
        }

        public Quiz GetQuizzesByName(string quizName)
        {
            Question question;
            Quiz quiz;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM QuizTest WHERE QuizName ='{quizName}'", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        question = new Question()
                        {
                            Text = reader["Question"].ToString(),
                            PossibleAnswers = reader["PossibleAnswers"].ToString().Split(';'),
                            CorrectAnswer = reader["CorrectAnswer"].ToString()
                        };

                        quiz = new Quiz()
                        {
                            Id = (int)reader["QuizId"],
                            Title = quizName,
                            Questions = new List<Question> { question },
                            Category = reader["Category"].ToString(),
                        };

                    }
                }
                return quiz;
            }
        }

        public List<Quiz> GetQuizzesByCategory(string category)
        {
            Quiz quiz = new Quiz(0, "", "");
            List<Quiz> tempQuizList = new List<Quiz>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM QuizTest WHERE Category ='{category}'", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for(int i = 0; i < 4; i++)
                        {
                            string correctAnswer = reader["CorrectAnswer"].ToString();
                            string[] possibleAnswerArray = reader["PossibleAnswers"].ToString().Split(';');
                            string questionText = reader["Question"].ToString();
                            Question question = new Question(questionText, possibleAnswerArray, correctAnswer);
                            quiz.Questions.Add(question);
                        }
                        quiz.Id = (int)reader["QuizId"];
                        quiz.Title = reader["QuizName"].ToString();
                        quiz.Category = reader["Category"].ToString();
                        tempQuizList.Add(quiz);
                        quiz = new Quiz(0, "", "");
                    }
                }
            }
            return tempQuizList;
        }
    }
}
