using System;
using System.Data;
using System.Reflection;
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
            string connString = "Server=localhost;Uid=root;Database=databasetest;Port=3306;Pwd=1234";
            conn = new MySqlConnection(connString);
        }

        //회원가입 
        public void SignIn(UsersModel user)
        {
            string query = "INSERT INTO OTT.Users (user_name, id, pw, nick_name) VALUES (@UserName, @ID, @PW, @NickName)"; try
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
        //로그인
        public UsersModel LoginUser(string id, string pw)
        {
            UsersModel user = null;
            string query = "SELECT * FROM OTT.users WHERE id = @id AND pw = @pw";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@pw", pw);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = new UsersModel
                    {
                        PK = Convert.ToInt32(reader["pk"]),
                        ID = reader["id"].ToString(),
                        UserName = reader["user_name"].ToString(),
                        PW = reader["pw"].ToString(),
                        NickName = reader["nick_name"].ToString()
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

            return user;
        }
        //id 중복 체크 
        public UsersModel IDCheck(string id)
        {
            UsersModel user = null;
            string query = "SELECT * FROM OTT.users WHERE id = @id";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
              

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = new UsersModel
                    {
                        PK = Convert.ToInt32(reader["pk"]),
                        ID = reader["id"].ToString(),
                        UserName = reader["user_name"].ToString(),
                        PW = reader["pw"].ToString(),
                        NickName = reader["nick_name"].ToString()
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

            return user;
        }
        //nickname 중복 체크
        public UsersModel NickNameCheck(string nickName)
        {
            UsersModel user = null;
            string query = "SELECT * FROM OTT.users WHERE nick_name = @nick_name";

            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nick_name", nickName);


                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    user = new UsersModel
                    {
                        PK = Convert.ToInt32(reader["pk"]),
                        ID = reader["id"].ToString(),
                        UserName = reader["user_name"].ToString(),
                        PW = reader["pw"].ToString(),
                        NickName = reader["nick_name"].ToString()
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

            return user;
        }

    }
    }
