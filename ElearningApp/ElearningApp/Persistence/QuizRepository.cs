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
            quizzes = GetAll();
        }

        public List<Quiz> GetAll()
        {
            Quiz quiz = new Quiz(0, "");
            List<Quiz> tempQuizList = new List<Quiz>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM QuizTest2", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quiz.Id = (int)reader["quiz_id"];
                        quiz.Category = reader["quiz_category"].ToString();
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
            Quiz quiz = new Quiz(0, "");
            List<Quiz> tempQuizList = new List<Quiz>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM QuizTest2 WHERE quiz_category='{category}'", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quiz.Id = (int)reader["quiz_id"];
                        quiz.Category = reader["quiz_category"].ToString();
                        quiz.Questions = GetQuestionsByQuizId(quiz.Id);
                        return quiz;
                    }
                }
            }
            return quiz;
        }

        private List<Question> GetQuestionsByQuizId(int quiz_id)
        {
            Question question = new Question("", null, "", "");
            List<Question> tempQuestionList = new List<Question>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                {
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Question WHERE quiz_id ='{quiz_id}'", conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string questionText = reader["question_text"].ToString();
                            string[] possibleAnswerArray = reader["possible_answers"].ToString().Split(';');
                            string correctAnswer = reader["correct_answer"].ToString();
                            string category = reader["category"].ToString();
                            question = new Question(questionText, possibleAnswerArray, correctAnswer, category);
                            tempQuestionList.Add(question);
                        }
                    }
                }
            }
            return tempQuestionList;
        }
    }
}
