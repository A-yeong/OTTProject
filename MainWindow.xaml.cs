using OTTProject.Views;
using System.Windows;

namespace OTTProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isUserLoggedIn = ((App)Application.Current).IsUserLoggedIn();


            if (isUserLoggedIn)
            {
                int userPk = ((App)Application.Current).UserPK.Value;
                MessageBox.Show($"사용자 {userPk}가 로그인 상태입니다.", "로그인 상태", MessageBoxButton.OK, MessageBoxImage.Information);
                MainFrame.Navigate(new MyPage());  
            }
            else
            {
               
                MainFrame.Navigate(new Login());  
            }
        }
    }
}
