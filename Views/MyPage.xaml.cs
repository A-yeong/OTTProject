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

namespace OTTProject.Views
{
    /// <summary>
    /// MyPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MyPage : Page
    {
        UsersModel userModel;
        UsersViewModels userViewModel = new UsersViewModels();
        private StarViewModel starViewModel = new StarViewModel();
        private ReviewAndNickNameViewModels reviewAndNickNameViewModel = new ReviewAndNickNameViewModels();
        private ReviewViewModel reviewViewModel = new ReviewViewModel();
        private DiaryTitleAndContentViewModel diaryTitleAndContentViewModel = new DiaryTitleAndContentViewModel();
        private ContentsRepository contentsRepo = new ContentsRepository();
        private DiaryViewModels diaryViewModels = new DiaryViewModels();

        private ContentViewModels contentViewModels = new ContentViewModels();

        public MyPage()
        {
            InitializeComponent();
            Loaded += MyPage_Load;
        }

        public void MyPage_Load(object sender, RoutedEventArgs e)
        {
            int userPk = ((App)Application.Current).UserPK.Value;
            //MessageBox.Show(userPk.ToString());
            userModel = userViewModel.FindNickName(userPk);
            //string message = $"PK : {userModel.PK}\n" +
            //                $"UserName : {userModel.UserName}\n" +
            //                $"ID : {userModel.ID}\n" +
            //                $"PW : {userModel.PW}\n" +
            //                $"NickName : {userModel.NickName}\n";
            //MessageBox.Show(message);
            nickName.Text = userModel.NickName + "님";

            List<DiaryTitleAndContentModel> diaryTitleAndContentModel = diaryTitleAndContentViewModel.DiaryList(userPk);
            DiaryListView.ItemsSource = diaryTitleAndContentModel;
            List<string> urlImgs = starViewModel.starContentByUserAll();
            starContentList.ItemsSource = urlImgs;
            List<ReviewAndNickNameModel> review = reviewAndNickNameViewModel.ReviewListByUser();
            reviewList.ItemsSource = review;


        }

        public void Review_DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ReviewAndNickNameModel reviewModel = (ReviewAndNickNameModel)button.Tag;
            reviewViewModel.myPageDeleteReview(reviewModel, NavigationService);
   
        }

        public void Delete_Diary_Click(object sender, RoutedEventArgs e) {
            Button button = (Button)sender;
            DiaryTitleAndContentModel diaryModel = (DiaryTitleAndContentModel)button.Tag;
            diaryViewModels.DeleteDiary(diaryModel.PK, NavigationService);

        }

        public void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DiaryTitleAndContentModel diaryModel = (DiaryTitleAndContentModel)button.Tag;

            //string title = diaryModel.Title;
            //MessageBox.Show(title);

            ContentsModel content = contentsRepo.ContentByPk(diaryModel.ContentPK);

            Diary diaryPage = new Diary(content, true)
            {
                PK = diaryModel.PK
            };

            NavigationService.Navigate(diaryPage);
        }

        public void LogOut(object sender, RoutedEventArgs e) {
            userViewModel.LogOut(NavigationService);
        }

        private void Img_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string url = (string)button.Tag;
            contentViewModels.FindContentByUrl(url, NavigationService);
        }

    }
}
