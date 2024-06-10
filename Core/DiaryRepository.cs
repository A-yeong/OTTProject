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
    internal class DiaryRepository
    {
        private MySqlConnection conn;

        public DiaryRepository()
        {
            string connString = "Server=localhost;Uid=root;Database=ott;Port=3306;Pwd=1234";
            conn = new MySqlConnection(connString);
        }

        public ContentsModel ContentModel { get; set; }

        public void DiaryWrite(DiaryModel diaryModel)
        {
            string query = "INSERT INTO OTT.Diary (content, date_time, star, content_pk, user_pk) VALUES (@content, @date_time, @star, @content_pk, @user_pk)";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@content", diaryModel.Content);
                cmd.Parameters.AddWithValue("@date_time", diaryModel.DateTime);
                cmd.Parameters.AddWithValue("@star", diaryModel.Star);
                cmd.Parameters.AddWithValue("@content_pk", diaryModel.ContentPk);
                cmd.Parameters.AddWithValue("@user_pk", diaryModel.UserPk);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // 예외 처리 (로그 기록 등)
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
