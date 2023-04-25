using ElearningApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Persistence
{
    public class QuizRepo
    {
        private List<Quiz> quizList;
        string ConnectionString = "Server=10.56.8.36; database=P3_DB_2023_03; user id=P3_PROJECT_USER_03; password=OPENDB_03; TrustServerCertificate=true;";

        public List<Quiz> LoadQuizDescriptions()
        {

            quizList = new List<Quiz>();

            using(SqlConnection conn = new SqlConnection(ConnectionString)) 
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select * From Quiz", conn);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Quiz quiz = new Quiz()
                        {

                            Description = reader["Description"].ToString(),
                            Result = int.Parse(reader["Result"].ToString()),
                            GuideName = reader["GuideName"].ToString(),
                            Answers = reader["Answers"].ToString().Split(";")
                        };
                        quizList.Add(quiz);
                    }
                }
            }

            return quizList;

        }
    }
}

