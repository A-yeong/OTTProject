using OTTProject.Core;
using OTTProject.Models;
using OTTProject.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace OTTProject.Views
{
    
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
         
            string userName = UserNameTextBox.Text;
            string id = IDTextBox.Text;
            string pw = PWTextBox.Text;
            string nickName = NickNameTextBox.Text;

           
            UsersModel newUser = new UsersModel
            {
                UserName = userName,
                ID = id,
                PW = pw,
                NickName = nickName
            };

            UsersViewModels viewModel = new UsersViewModels();
            viewModel.SignUp_Click(newUser, NavigationService);
        }
    }
}
