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
        public void SignUp_Click(UsersModel usersModel, NavigationService navigationService)
        {
      
            Repository repo = new Repository();
          
            repo.SignIn( usersModel);

        
            MessageBox.Show("회원가입이 완료되었습니다.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

           
            navigationService?.Navigate(new Uri("Views/Login.xaml", UriKind.Relative));
        }

        public UsersModel Login_click(string id, string pw) {
            Repository repo = new Repository();
           
            UsersModel user = repo.LoginUser(id, pw);
            return user;
        }
    }
}
