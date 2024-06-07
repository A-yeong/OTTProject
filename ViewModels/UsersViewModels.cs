using OTTProject.Core;
using OTTProject.Models;
using System;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace OTTProject.ViewModels
{
    internal class UsersViewModels
    {
        Repository repo = new Repository();
        public void SignUp_Click(UsersModel usersModel, NavigationService navigationService)
        {
      
        
          
            repo.SignIn( usersModel);

        
            MessageBox.Show("회원가입이 완료되었습니다.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

           
            navigationService?.Navigate(new Uri("Views/Login.xaml", UriKind.Relative));
        }

        public UsersModel Login_click(string id, string pw) {
          
           
            UsersModel user = repo.LoginUser(id, pw);
            return user;
        }

        public UsersModel IsId(string id) {
            UsersModel user = repo.IDCheck(id);
            return user;
        
        }
    }
}
