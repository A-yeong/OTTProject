using OTTProject.Core;
using OTTProject.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace OTTProject.Views
{
    /// <summary>
    /// SignIn.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            // 입력된 값 가져오기
            string userName = UserNameTextBox.Text;
            string id = IDTextBox.Text;
            string pw = PWTextBox.Text;
            string nickName = NickNameTextBox.Text;

            // UsersModel 객체 생성
            UsersModel newUser = new UsersModel
            {
                UserName = userName,
                ID = id,
                PW = pw,
                NickName = nickName
            };

            // 데이터베이스에 삽입
            Repository repo = new Repository();
            string query = "INSERT INTO OTT.Users (user_name, id, pw, nick_name) VALUES (@UserName, @ID, @PW, @NickName)";
           repo.SignIn(query, newUser);
      
        


            // 로그인 페이지로 네비게이션
            //NavigationService?.Navigate(new Uri("Views/Login.xaml", UriKind.Relative));
        }
    }
}
