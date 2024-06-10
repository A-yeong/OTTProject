using OTTProject.Core;
using OTTProject.ViewModels;
using OTTProject.Models;
using OTTProject.Views;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Media;

namespace OTTProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ContentViewModels viewModels = new ContentViewModels();

        //로그인 버튼 클릭 
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            bool isUserLoggedIn = ((App)Application.Current).IsUserLoggedIn();


            if (isUserLoggedIn)
            {
                int userPk = ((App)Application.Current).UserPK.Value;
            
                
                MainFrame.Navigate(new MyPage());  
            }
            else
            {
               
                MainFrame.Navigate(new Login());  
            }
        }
        //커서 갔다 되거나 때면은 
        private void search_title_GotFocus(object sender, RoutedEventArgs e)
        {
            if (search_title.Text == "영화 또는 TV 프로그램 입력")
            {
                search_title.Text = string.Empty;
                search_title.Foreground = Brushes.Black; 
            }
        }

        private void search_title_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(search_title.Text))
            {
                search_title.Text = "영화 또는 TV 프로그램 입력";
                search_title.Foreground = Brushes.Gray; 
            }
        }
        //검색 버튼 
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string title = search_title.Text;
            ContentsModel model = viewModels.SearchContents(title);

            if (model != null)
            {
                SearchPage searchPage = new SearchPage
                {
                    ContentModel = model
                };

                MainFrame.Navigate(searchPage);
            }
            else
            {
                MessageBox.Show("No content found with the given title.");
            }
        }

        private void MainFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
        //로고 클릭하면 메인으로 넘어감 
        private void LogoClicked(object sender, RoutedEventArgs e) {
            MainFrame.Navigate(new MainPage());
        }
    }
}
