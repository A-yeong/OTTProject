using MySqlConnector;
using OTTProject.Models;
using OTTProject.Views;
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

        public void DiaryModify(DiaryModel diaryModel)
        {
            string query = "UPDATE OTT.Diary SET content = @content, date_time = @date_time, star = @star, content_pk = @content_pk, user_pk = @user_pk WHERE pk = @pk";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pk", diaryModel.Pk);
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

        public List<DiaryModel> GetUserDiary(int? userPk)
        {
            List<DiaryModel> diaries = new List<DiaryModel>();
            string query = "SELECT * FROM OTT.diary WHERE user_pk = @userPk";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userPk", userPk);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DiaryModel diary = new DiaryModel
                    {
                        Pk = reader.GetInt32("pk"),
                        Content = reader.GetString("content"),
                        DateTime = reader.GetString("date_time"),
                        Star = reader.GetInt32("star"),
                        ContentPk = reader.GetInt32("content_pk"),
                        UserPk = reader.GetInt32("user_pk")
                    };
                    diaries.Add(diary);
                }
                reader.Close();
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

            return diaries;
        }

        public DiaryModel getDiaryModel(int? pk)
        {
            DiaryModel diary = null;
            string query = "SELECT * FROM OTT.diary WHERE pk = @pk";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pk", pk);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                diary = new DiaryModel
                {
                    Pk = reader.GetInt32("pk"),
                    Content = reader.GetString("content"),
                    DateTime = reader.GetString("date_time"),
                    Star = reader.GetInt32("star"),
                    ContentPk = reader.GetInt32("content_pk"),
                    UserPk = reader.GetInt32("user_pk")
                };

                reader.Close();
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

            return diary;
        }
    }
}