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
    internal class ReviewRepository
    {
        private MySqlConnection conn;

        public ReviewRepository()
        {
            string connString = "Server=localhost;Uid=root;Database=ott;Port=3306;Pwd=1234";
            conn = new MySqlConnection(connString);
        }
        //컨텐츠별 후기 보기
        public List<ReviewModel> GetReviewsByContentPk(int? contentPk)
        {
            List<ReviewModel> reviews = new List<ReviewModel>();
            string query = "SELECT * FROM OTT.Review WHERE content_pk = @ContentPk";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ContentPk", contentPk);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ReviewModel review = new ReviewModel
                    {
                        PK = reader.GetInt32("pk"),
                        ContentPk = reader.GetInt32("content_pk"),
                        UserPk = reader.GetInt32("user_pk"),
                        Star = reader.GetInt32("star"),
                        Content = reader.GetString("content")
                    };
                    reviews.Add(review);
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

            return reviews;
        }
        //사용자별 후기 모두 보기
        public List<ReviewModel> GetReivesByUser()
        {
            int userPk = ((App)Application.Current).UserPK.Value;
            List<ReviewModel> reviews = new List<ReviewModel>();
            string query = "SELECT * FROM OTT.Review WHERE user_pk = @UserPk";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserPk", userPk);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ReviewModel review = new ReviewModel
                    {
                        PK = reader.GetInt32("pk"),
                        ContentPk = reader.GetInt32("content_pk"),
                        UserPk = reader.GetInt32("user_pk"),
                        Star = reader.GetInt32("star"),
                        Content = reader.GetString("content")
                    };
                    reviews.Add(review);
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

            return reviews;
        }
        //후기 등록 
        public void CreateReview(ReviewModel reviewModel)
        {
            string query = "INSERT INTO OTT.Review (content_pk, user_pk, star, content) VALUES (@ContentPk, @UserPk, @Star, @Content)"; try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ContentPk", reviewModel.ContentPk);
                cmd.Parameters.AddWithValue("@UserPk", reviewModel.UserPk);
                cmd.Parameters.AddWithValue("@Star", reviewModel.Star);
                cmd.Parameters.AddWithValue("@Content", reviewModel.Content);

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

        //후기 삭제
        public void DeleteReview(ReviewAndNickNameModel reviewModel)
        {
            string query = "DELETE FROM OTT.Review WHERE PK = @PK";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PK", reviewModel.PK);

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
