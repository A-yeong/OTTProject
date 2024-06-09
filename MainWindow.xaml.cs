using OTTProject.Core;
using OTTProject.ViewModels;
using OTTProject.Models;
using OTTProject.Views;
using System.Windows;
using System.Windows.Navigation;

namespace OTTProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ContentViewModels viewModels = new ContentViewModels();

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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string title = search_title.Text;
            ContentsModel model = viewModels.SearchContents(title);
            SearchPage.model = model;
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
