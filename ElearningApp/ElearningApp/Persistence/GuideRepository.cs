using ElearningApp.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Persistence
{
    public class GuideRepository
    {

        private List<Guide> guides;

        string ConnectionString = "Server=10.56.8.36; database=P3_DB_2023_03; user id=P3_PROJECT_USER_03; password=OPENDB_03; TrustServerCertificate=true;";


        public List<Guide> GetAllGuides() 
        {
            guides = new List<Guide>();

            using(SqlConnection conn = new SqlConnection(ConnectionString)) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Guide", conn);
            
                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {

                    while (reader.Read()) 
                    {
                        Guide guide = new Guide
                        {
                            GuideName = reader["GuideName"].ToString(),
                            LearningMaterial = reader["LearningMaterial"].ToString(),
                        };
                        guides.Add(guide);  
                    }
                }
            }
            return guides;
        }

        public void CreateGuide(string guideName) 
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = $"SELECT LearningMaterial FROM Guide WHERE GuideName = '{guideName}'";
                using SqlCommand cmd = new SqlCommand(query);
                cmd.Connection = conn;

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var data = (byte[])reader["LearningMaterial"];
                    if (data == null) throw new Exception("Contents is null");

                    using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Path.Combine($"{guideName}.pdf"))))
                    {
                        writer.Write(data);
                    }
                }
            }
        }

        public void SaveFile(string fileName, string filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] byteArray = new byte[stream.Length];
                stream.Read(byteArray, 0, byteArray.Length);

                string sqlQuery = "INSERT INTO Guide(GuideName, LearningMaterial) VALUES(@fileName, @learningMaterial)";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = fileName;
                    cmd.Parameters.Add("@learningMaterial", SqlDbType.VarBinary).Value = byteArray;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete() 
        {
        
        }

    }
}
