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

using OTTProject.ViewModels;
using OTTProject.Models;
using Microsoft.VisualBasic;
using System.Globalization;

namespace OTTProject.Views
{
    /// <summary>
    /// SearchPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();

            Loaded += SearchPage_Loaded; // 페이지 로드 이벤트에 핸들러 추가
        }

        public string TitleQuery { get; set; }
        public ContentsModel ContentModel { get; set; }
        private int filledStarCount = 0;
       private ReviewViewModel reviewViewModel = new ReviewViewModel();
        private ReviewAndNickNameViewModels reviewAndNickNameModelView = new ReviewAndNickNameViewModels();
   


        //처음 로드
        private void SearchPage_Loaded(object sender, RoutedEventArgs e)
        {
            var userPk = ((App)Application.Current).UserPK;

            if (userPk != null)
            {
                reviewGrid.Visibility = Visibility.Visible;
            
            }
            else
            {
                reviewGrid.Visibility = Visibility.Collapsed;
              
            }

            if (ContentModel != null)
            {   //ott처리
                string ottStr = ContentModel.Ott;
                string[] ottArray = ottStr.Split(',');
                List<string> ottSources = new List<string>();
                foreach(string value in ottArray) {
                    if (value == "넷플릭스") {
                        ottSources.Add("/Resources/netflix.png");
                    }
                    else {
                        ottSources.Add("/Resources/disney_plus.png");
                    }
                }
              
                ottList.ItemsSource = ottSources;



                title.Text = ContentModel.ContentName; // ContentModel의 제목을 표시
                genre.Text = ContentModel.Genre;
                synopsis.Text = ContentModel.Synopsis;

                // 이미지 URL을 BitmapImage로 변환하여 Image 컨트롤에 할당
                if (!string.IsNullOrEmpty(ContentModel.ImgUrl))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(ContentModel.ImgUrl, UriKind.Absolute);
                    bitmap.EndInit();
                    content_img.Source = bitmap;
                }

                List<ReviewAndNickNameModel> reviewAndNickNameList = reviewAndNickNameModelView. ReviewList(ContentModel.PK);
                foreach (var review in reviewAndNickNameList)
                {
                    if (review.UserPk == userPk)
                    {
                        review.CanEdit = true;
                        review.CanDelete = true;
                    }
                    else
                    {
                        review.CanEdit = false;
                        review.CanDelete = false;
                    }
                }

                reviewListView.ItemsSource = reviewAndNickNameList;
            }
            else
            {
                MessageBox.Show("ContentModel is null.");
            }
        }
        //별 클릭
        private void StarButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            TextBlock starIcon = button.Content as TextBlock;

            if (starIcon.Text == "☆")
            {
                // 클릭된 경우: 채워진 별로 변경
                starIcon.Text = "★";
                starIcon.Foreground = Brushes.Yellow; // 채워진 별 색상 설정
                filledStarCount++;
            }
            else
            {
                // 클릭되지 않은 경우: 일반 별로 변경
                starIcon.Text = "☆";
                starIcon.Foreground = Brushes.Gray; // 일반 별 색상 설정
                filledStarCount--;
            }

           
        }
        //후기 등록
        private void createReview(object sender, RoutedEventArgs e)
        {
            if (ContentModel != null)
            {
                int? contentPk = ContentModel.PK;
                int? userPk = ((App)Application.Current).UserPK;
                int star = filledStarCount;
                string content = review.Text;
                string message = $"PK: {contentPk.ToString()}\n" +
                                 $"userPk: {userPk.ToString()}\n" +
                                 $"star: {star.ToString()}\n" +
                                 $"content: {content}\n";
                ReviewModel newReview = new ReviewModel
                {
                    ContentPk = contentPk,
                    UserPk = userPk,
                    Star = star,
                    Content = content
                };

                reviewViewModel.createReview(newReview, ContentModel, NavigationService);

            }
        }

     

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ReviewAndNickNameModel reviewModel = (ReviewAndNickNameModel)button.Tag;
            reviewViewModel.deleteReview(reviewModel, ContentModel, NavigationService);
            // 삭제 기능 구현
        }

 

    }
}
