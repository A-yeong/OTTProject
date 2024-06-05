using System;
using System.Data;
using System.Windows;
using MySqlConnector;
using OTTProject.Models;

namespace OTTProject.Core
{
    internal class Repository
    {
        private MySqlConnection conn;

        public Repository()
        {
            string connString = "Server=localhost;Uid=root;Database=databasetest;Port=3307;Pwd=1234";
            conn = new MySqlConnection(connString);
        }
    

        public void SignIn(string query, UsersModel user)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@PW", user.PW);
                cmd.Parameters.AddWithValue("@NickName", user.NickName);

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
