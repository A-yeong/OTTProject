using MySqlConnector;
using OTTProject.Models;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;

namespace OTTProject.Core
{
    internal class StarRepository
    {
        private MySqlConnection conn;

        public StarRepository()
        {
            string connString = "Server=localhost;Uid=root;Database=ott;Port=3306;Pwd=1234";
            conn = new MySqlConnection(connString);
        }
        //해당 컨텐츠가 즐겨찾기를 했는지 
        public StarModel GetStar(int? contentPk) {
            int userPk = ((App)Application.Current).UserPK.Value;
            StarModel model = null;
            string query = "SELECT * FROM OTT.star WHERE content_pk = @contentPk AND user_pk = @userPk";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@contentPk", contentPk);
                cmd.Parameters.AddWithValue("@userPk", userPk);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    model = new StarModel
                    {
                        PK = Convert.ToInt32(reader["pk"]),
                        ContentPk = Convert.ToInt32(reader["content_pk"]),
                        UserPk = Convert.ToInt32(reader["user_pk"])
                    
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

            return model;

        }
        //즐겨찾기 추가

        public void CreateStar(int? contentPk)
        {
            int userPk = ((App)Application.Current).UserPK.Value;
            string query = "INSERT INTO OTT.star (content_pk, user_pk) VALUES ( @ContentPk, @UserPk )"; try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ContentPk", contentPk);
                cmd.Parameters.AddWithValue("@UserPk", userPk);

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

        //즐겨찾기 삭제
        public void DeleteStar(StarModel starModel)
        {
            string query = "DELETE FROM OTT.star WHERE PK = @PK";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@PK", starModel.PK);

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
