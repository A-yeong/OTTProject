using MySqlConnector;
using OTTProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.Core
{
    class ContentsRepository
    {
        private MySqlConnection conn;

        public ContentsRepository()
        {
            string connString = "Server=localhost;Uid=root;Database=databasetest;Port=3306;Pwd=1234";
            conn = new MySqlConnection(connString);
        }

        // content 찾기
        public ContentsModel SearchContents(string title)
        {
            ContentsModel contents = null;
            string query = "SELECT * FROM OTT.content WHERE content_name = @title";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);


                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    contents = new ContentsModel
                    {
                        PK = Convert.ToInt32(reader["pk"]),
                        ContentName = reader["content_name"].ToString(),
                        ImgUrl = reader["img_url"].ToString(),
                        Synopsis = reader["synopsis"].ToString(),
                        Genre = reader["genre"].ToString(),
                        Ott = reader["ott"].ToString(),
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return contents;
        }
    }
}
