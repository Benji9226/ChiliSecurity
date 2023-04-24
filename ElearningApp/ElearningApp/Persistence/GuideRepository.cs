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
        string connectionString = "Server=10.56.8.36; database=P3_DB_2023_03; user id=P3_PROJECT_USER_03; password=OPENDB_03; TrustServerCertificate=true;";

        public GuideRepository()
        {
            guides = GetAll();
        }

        public void Add(Guide guideToAdd)
        {
            guides.Add(guideToAdd);
            string sqlQuery = "INSERT INTO Guide(GuideName, LearningMaterial) VALUES(@guideName, @learningMaterial)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.Add("@guideName", SqlDbType.NVarChar).Value = guideToAdd.GuideName;
                cmd.Parameters.Add("@learningMaterial", SqlDbType.VarBinary).Value = guideToAdd.LearningMaterial;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Guide> GetAll()
        {
            List<Guide> guides = new List<Guide>();
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Guide", conn);
            
                using (SqlDataReader reader = cmd.ExecuteReader()) 
                {

                    while (reader.Read())
                    {
                        Guide guide = new Guide(reader["GuideName"].ToString(), (byte[])reader["LearningMaterial"]);
                        guides.Add(guide);  
                    }
                }
            }
            return guides;
        }

        public Guide GetByName(string guideToGetName)
        {
            foreach (Guide guide in guides)
            {
                if (guide.GuideName == guideToGetName)
                {
                    return guide;
                }
            }
            return null;
        }

        public void Update(Guide guideToUpdate, string updatedGuideName, byte[] updatedLearningMaterial)
        {
            foreach (Guide guide in guides)
            {
                if (guide.GuideName == guideToUpdate.GuideName && guide.LearningMaterial == guideToUpdate.LearningMaterial)
                {
                    // TODO: Implement for DB
                    guide.GuideName = updatedGuideName;
                    guide.LearningMaterial = updatedLearningMaterial;
                    break;
                }
            }
        }

        public void Delete(Guide guideToDelete) 
        {
            foreach (Guide guide in guides)
            {
                if (guide.GuideName == guideToDelete.GuideName && guide.LearningMaterial == guideToDelete.LearningMaterial)
                {
                    // TODO: Implement for DB
                    guides.Remove(guide);
                    break;
                }
            }
        }
    }
}
