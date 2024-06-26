using MySqlConnector;
using OTTProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OTTProject.Core
{
    class ContentsRepository
    {
        private MySqlConnection conn;

        public ContentsRepository()
        {
            string connString = "Server=localhost;Uid=root;Database=ott;Port=3306;Pwd=1234";
            conn = new MySqlConnection(connString);
        }
        //db연결 테스트 임의로 만들어둠 
        //public void TestDatabaseConnection()
        //{
        //    try
        //    {
        //        conn.Open();
        //        MessageBox.Show("데이터베이스 연결 성공");
        //        conn.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show("데이터베이스 연결 실패: " + ex.Message);
        //    }
        //    finally
        //    {
        //        if (conn.State == System.Data.ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //    }
        //}
        //imgUrl로 content찾기
        public ContentsModel FindContentByUrl(string url)
        {
            ContentsModel contents = null;
            string query = "SELECT * FROM OTT.content WHERE img_url = @ImgUrl";
            // MessageBox.Show(title);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ImgUrl", url);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
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
                }

                if (contents != null)
                {

                }
                else
                {
                    MessageBox.Show("No content found with the given title.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("데이터베이스 연결 실패: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return contents;
        }


        // content 찾기
        public ContentsModel SearchContents(string title)
        {
            ContentsModel contents = null;
            string query = "SELECT * FROM OTT.content WHERE content_name = @title";
            // MessageBox.Show(title);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", title);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
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
                }

                if (contents != null)
                {
        
                }
                else
                {
                    MessageBox.Show("No content found with the given title.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("데이터베이스 연결 실패: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return contents;
        }



        //pk로 컨텐트 가져오기 
        public ContentsModel ContentByPk(int? pk)
        {
            ContentsModel contents = null;
            string query = "SELECT * FROM OTT.content WHERE pk = @PK";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PK", pk);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
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
                }

           
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("데이터베이스 연결 실패: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return contents;
        }

        public string getTitle(int? pk)
        {
            string title = "";
            string query = "SELECT * FROM OTT.content WHERE pk = @PK";
            // MessageBox.Show(title);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PK", pk);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        title = reader["content_name"].ToString();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("데이터베이스 연결 실패: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return title;
        }

    }
}
