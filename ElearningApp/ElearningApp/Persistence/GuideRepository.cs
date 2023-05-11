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
        private bool isCacheValid;
        string connectionString = "Server=10.56.8.36; database=P3_DB_2023_03; user id=P3_PROJECT_USER_03; password=OPENDB_03; TrustServerCertificate=true;";

        public GuideRepository()
        {
            guides = new List<Guide>();
            isCacheValid = false;
        }

        public void Add(Guide guideToAdd)
        {
            guides.Add(guideToAdd);
            AddToDb(guideToAdd);
        }

        public void AddToDb(Guide guideToAdd)
        {
            string sqlQuery = "INSERT INTO Guide(GuideName, LearningMaterial, Category) VALUES(@guideName, @learningMaterial, @category)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.Parameters.Add("@guideName", SqlDbType.NVarChar).Value = guideToAdd.GuideName;
                cmd.Parameters.Add("@learningMaterial", SqlDbType.VarBinary).Value = guideToAdd.LearningMaterial;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar).Value = guideToAdd.Category;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Guide> GetAll()
        {
            guides = new List<Guide>();
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            IsCacheValidCheck();
            return guides;
        }

        public List<Guide> GetAllFromDb()
        {
            List<Guide> guides = new List<Guide>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT GuideName, LearningMaterial, Category FROM Guide", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Guide guide = new Guide(reader["GuideName"].ToString(), (byte[])reader["LearningMaterial"], reader["Category"].ToString());
                        guides.Add(guide);
                    }
                }
            }
            return guides;
        }

        public Guide GetByNameAndCategory(string guideToGetName, string guideToGetCategory)
        {
            IsCacheValidCheck();
            foreach (Guide guide in guides)
            {
                if (guide.GuideName == guideToGetName && guide.Category == guideToGetCategory)
                {
                    return guide;
                }
            }
            throw new Exception($"Guide with the name {guideToGetName} and category {guideToGetCategory} was not found.");
        }

        public void Update(Guide guideToUpdate, string updatedGuideName, byte[] updatedLearningMaterial, string updatedCategory)
        {
            IsCacheValidCheck();
            foreach (Guide guide in guides)
            {
                if (guide.GuideName == guideToUpdate.GuideName && guide.Category == guideToUpdate.Category)
                {
                    string sqlQuery = "UPDATE Guide SET GuideName = @GuideName, LearningMaterial = @LearningMaterial, Category = @Category WHERE GuideName = @guideToUpdateGuideName AND Category = @guideToUpdateCategory";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                        cmd.Parameters.Add("@guideToUpdateGuideName", SqlDbType.NVarChar).Value = guideToUpdate.GuideName;
                        cmd.Parameters.Add("@guideToUpdateCategory", SqlDbType.NVarChar).Value = guideToUpdate.Category;
                        cmd.Parameters.Add("@GuideName", SqlDbType.NVarChar).Value = updatedGuideName;
                        cmd.Parameters.Add("@LearningMaterial", SqlDbType.VarBinary).Value = updatedLearningMaterial;
                        cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = updatedCategory;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    break;
                }
            }
        }

        public void Delete(Guide guideToDelete) 
        {
            IsCacheValidCheck();
            foreach (Guide guide in guides)
            {
                if (guide.GuideName == guideToDelete.GuideName && guide.Category == guideToDelete.Category)
                {
                    string sqlQuery = "DELETE FROM Guide WHERE GuideName = @GuideName AND Category = @Category";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                        cmd.Parameters.Add("@GuideName", SqlDbType.NVarChar).Value = guideToDelete.GuideName;
                        cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = guideToDelete.Category;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    guides.Remove(guide);
                    break;
                }
            }
        }

        private void IsCacheValidCheck()
        {
            if (!isCacheValid)
            {
                guides = GetAllFromDb();
                isCacheValid = true;
            }
        }
    }
}