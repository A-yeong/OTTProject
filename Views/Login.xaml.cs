using OTTProject.Core;
using OTTProject.Models;
using OTTProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OTTProject
{
    
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/SignIn.xaml", UriKind.Relative));
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string id = IDTextBox.Text;
            string pw = PWPasswordBox.Password;

            UsersViewModels users = new UsersViewModels();
            UsersModel user = users.Login_click(id, pw);

            if (user != null)
            {
                // 로그인 성공
                ((App)Application.Current).UserPK = user.PK; // UserPK 저장
                MessageBox.Show($"로그인 성공! 사용자 정보:\n\nUserPK: {((App)Application.Current).UserPK}\npk:{user.PK}UserName: {user.UserName}\nID: {user.ID}\nNickName: {user.NickName}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // 메인 페이지로 이동
                NavigationService?.Navigate(new Uri("Views/MainPage.xaml", UriKind.Relative));
            }
            else
            {
                // 로그인 실패
                MessageBox.Show("아이디 또는 비밀번호가 잘못되었습니다.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      


    }

}
