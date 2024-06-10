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

namespace OTTProject.Views
{
    /// <summary>
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }
       private StarViewModel starViewModel = new StarViewModel();
        private DiaryTitleAndContentViewModel diaryTitleAndContentViewModel = new DiaryTitleAndContentViewModel();
        private DiaryViewModels diaryViewModels = new DiaryViewModels();
        private ContentViewModels ContentViewModels = new ContentViewModels();

        private void MainPage_Loaded(object sender, RoutedEventArgs e) {
            var userPk = ((App)Application.Current).UserPK;

            if (userPk != null)
            {
                starContentList.Visibility = Visibility.Visible;
                List<string> contentImgUrls = starViewModel.starContentByUser();
                starContentList.ItemsSource = contentImgUrls;
                List<DiaryTitleAndContentModel> diaryTitleAndContentModel = diaryTitleAndContentViewModel.DiaryList(userPk);
                DiaryListView.ItemsSource = diaryTitleAndContentModel;


            }
            else{
                starContentList.Visibility = Visibility.Collapsed;

            }
       
        }
        private void Img_Click(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            string  url = (string)button.Tag;
            ContentViewModels.FindContentByUrl(url, NavigationService);
        }


    }
}
