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

        /// <summary>
        /// Guide repository constructor
        /// Upon creation, fills up guide list with all guides from GetAllGuides() Method.
        /// </summary>
        public GuideRepository()
        {
            GetAllGuides();
        }

        /// <summary>
        /// Functionality to get all guides.
        /// </summary>
        /// <returns>A List of all guide objects</returns>
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
                            LearningMaterial = (byte[])reader["LearningMaterial"]
                        };
                        guides.Add(guide);  
                    }
                }
            }
            return guides;
        }

        /// <summary>
        /// Gets a specific guide from parameter guideName.
        /// </summary>
        /// <param name="guideName"></param>
        /// <returns>A guide object</returns>
        public Guide GetByName(string guideName)
        {
            foreach (Guide guide in guides)
            {
                if (guide.GuideName == guideName)
                {
                    return guide;
                }
            }
            return null;
        }

        /// <summary>
        /// Method for saving a given guide to the database and into the local repository.
        /// </summary>
        /// <param name="guideName"></param>
        /// <param name="filePath"></param>
        public void SaveFile(string guideName, string filePath)
        {
            // Adds guide to database
            using (Stream stream = File.OpenRead(filePath))
            {
                byte[] byteArray = new byte[stream.Length];
                stream.Read(byteArray, 0, byteArray.Length);

                //Spørg Leif hvordan man skal tildele variabler ordenligt
                string sqlQuery = "INSERT INTO Guide(GuideName, LearningMaterial) VALUES(@guideName, @learningMaterial)";

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.Add("@guideName", SqlDbType.NVarChar).Value = guideName;
                    cmd.Parameters.Add("@learningMaterial", SqlDbType.VarBinary).Value = byteArray;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Adds guide to local repo
                Guide guide = new Guide
                {
                    GuideName = guideName,
                    LearningMaterial = byteArray
                };

                guides.Add(guide);
            }
        }

        public void Delete() 
        {
        
        }

    }
}
