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
        UsersViewModels userViewModel = new UsersViewModels();

        bool isID = true;
        bool isNickName = true;
        string id = "";
        string nickname = "";
        //true면 회원가입 가능,false면 회원가입 불가
        private bool isSignUp()
        {
            if (UserNameTextBox.Text == "" || IDTextBox.Text == "" || PWTextBox.Password == "" || PWCheckTextBox.Password == "" || NickNameTextBox.Text == "") {
                MessageBox.Show("필수 입력값을 모두 입력해주세요");
                return false;
            }
            if (isID)
            {
                MessageBox.Show("아이디 중복체크해주세요.");
                return false;
            }
            if (isNickName)
            {
                MessageBox.Show("닉네임 중복체크해주세요.");
                return false;
            }
            if (id != IDTextBox.Text)
            {
                MessageBox.Show("다시 아이디 중복체크해주세요.");
                return false;
            }
            if (nickname != NickNameTextBox.Text)
            {
                MessageBox.Show("다시 닉네임 중복체크해주세요.");
                return false;
            }
            if (PWCheckTextBox.Password != PWTextBox.Password) {
                MessageBox.Show("비밀번호가 일치하지 않습니다");
                return false;
            }
            return true;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (isSignUp()) {
                string userName = UserNameTextBox.Text;
                string id = IDTextBox.Text;
                string pw = PWTextBox.Password;
                string nickName = NickNameTextBox.Text;


                UsersModel newUser = new UsersModel
                {
                    UserName = userName,
                    ID = id,
                    PW = pw,
                    NickName = nickName
                };


                userViewModel.SignUp_Click(newUser, NavigationService);
            }
         
          
        }
        private void IDCheck_Click(object sencer, RoutedEventArgs e)
        {
            UsersModel user = userViewModel.IsId(IDTextBox.Text);
            if (user != null)
            {
                MessageBox.Show("이미 존재하는 아이디입니다.");
                isID = true;
            }
            else {
                MessageBox.Show("사용 가능한 아이디입니다.");
                isID = false;
                id = IDTextBox.Text;
            }

        }

        private void NickName_Click(object sender, RoutedEventArgs e) {
            UsersModel user = userViewModel.IsId(NickNameTextBox.Text);
            if (user != null)
            {
                MessageBox.Show("이미 존재하는 닉네임입니다.");
                isNickName = true;
            }
            else
            {
                MessageBox.Show("사용 가능한 닉네임입니다.");
                isNickName = false;
                nickname = NickNameTextBox.Text;
            }
        }
    }
}
