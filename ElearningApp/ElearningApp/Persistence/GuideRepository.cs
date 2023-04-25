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
            List<Guide> guides = new List<Guide>();
            using(SqlConnection conn = new SqlConnection(connectionString)) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Guide", conn);
            
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
            foreach (Guide guide in guides)
            {
                // IMPLEMENT THIS IN DB AND CODE:
                // TWO GUIDES CAN HAVE SAME NAME, TWO GUIDES CAN HAVE SAME CATEGORY
                // BUT THERE CAN ONLY BE ONE WITH THE COMBO OF NAME AND CATEGORY
                // (ex. "Chili Installation", "Chili")
                // (ex. "EnergiFyn HOWTO", "EnergiFyn")
                if (guide.GuideName == guideToUpdate.GuideName && guide.Category == guideToUpdate.Category)
                {
                    // TODO: Implement for DB
                    guide.GuideName = updatedGuideName;
                    guide.LearningMaterial = updatedLearningMaterial;
                    guide.Category = updatedCategory;




                    break;
                }
            }
        }

        public void Delete(Guide guideToDelete) 
        {
            foreach (Guide guide in guides)
            {
                // IMPLEMENT THIS IN DB AND CODE:
                // TWO GUIDES CAN HAVE SAME NAME, TWO GUIDES CAN HAVE SAME CATEGORY
                // BUT THERE CAN ONLY BE ONE WITH THE COMBO OF NAME AND CATEGORY
                // (ex. "Chili Installation", "Chili")
                // (ex. "EnergiFyn HOWTO", "EnergiFyn")
                if (guide.GuideName == guideToDelete.GuideName && guide.Category == guideToDelete.Category)
                {
                    // TODO: Implement for DB
                    guides.Remove(guide);

                    //SHOULD WORK LIKE THIS:
                    string sqlQuery = "Delete from Guide Where GuideName = @GuideName And Category = @Category";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                        cmd.Parameters.Add("@GuideName", SqlDbType.NVarChar).Value = guideToDelete.GuideName;
                        cmd.Parameters.Add("@Category", SqlDbType.NVarChar).Value = guideToDelete.Category;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    break;
                }
            }
        }
    }
}
