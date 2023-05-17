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
        private bool isCacheValid;
        string connectionString = "Server=10.56.8.36; database=P3_DB_2023_03; user id=P3_PROJECT_USER_03; password=OPENDB_03; TrustServerCertificate=true;";

        public QuizRepository()
        {
            quizzes = new List<Quiz>();
            isCacheValid = false;
        }

        public List<Quiz> GetAll()
        {
            Quiz quiz = new Quiz(0, "");
            List<Quiz> tempQuizList = new List<Quiz>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Quiz", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quiz.Id = (int)reader["QuizID"];
                        quiz.Category = reader["QuizCategory"].ToString();
                        quiz.Questions = GetQuestionsByQuizId(quiz.Id);
                        tempQuizList.Add(quiz);
                        quiz = new Quiz(0, "");
                    }
                }
            }
            return tempQuizList;
        }

        public Quiz GetByCategory(string category)
        {
            IsCacheValidCheck();
            Quiz quiz = new Quiz(0, "");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Quiz WHERE QuizCategory='{category}'", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quiz.Id = (int)reader["QuizID"];
                        quiz.Category = reader["QuizCategory"].ToString();
                        quiz.Questions = GetQuestionsByQuizId(quiz.Id);
                        return quiz;
                    }
                }
            }
            return quiz;
        }

        private List<Question> GetQuestionsByQuizId(int quiz_id)
        {
            List<Question> tempQuestionList = new List<Question>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Question WHERE QuizID ='{quiz_id}'", conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string questionText = reader["QuestionText"].ToString();
                            string[] possibleAnswerArray = reader["PossibleAnswer"].ToString().Split(';');
                            string correctAnswer = reader["CorrectAnswer"].ToString();
                            string category = reader["Category"].ToString();
                            Question question = new Question(questionText, possibleAnswerArray, correctAnswer, category);
                            tempQuestionList.Add(question);
                        }
                    }
                }
            }
            return tempQuestionList;
        }

        private void IsCacheValidCheck()
        {
            if (!isCacheValid)
            {
                quizzes = GetAll();
                isCacheValid = true;
            }
        }
    }
}
