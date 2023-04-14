using ElearningApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.Persistence
{
    public class GuideRepository
    {

        private List<Guide> guides;

        string ConnectionString = "Server=10.56.8.36; database=P3_DB_2023_03; user id=P3_PROJECT_USER_03; password=OPENDB_03; TrustServerCertificate=true;";


        public void Add() 
        {

        }


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
        
        

        public void GetGuide(string name) 
        {
        
        }


        public void Update() 
        {

        }

        public void Delete() 
        {
        
        }

    }
}
