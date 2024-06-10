using Microsoft.VisualBasic;
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
using System.Windows.Shapes;

namespace OTTProject.Views
{
    /// <summary>
    /// Diary.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Diary : Page
    {
        private int filledStarCount = 0;
        public ContentsModel ContentModel { get; internal set; }
        public int ContentPK { get; set; }
        public Diary(ContentsModel contentModel)
        {
            InitializeComponent();
            ContentModel = contentModel;
            // 전달된 ContentModel을 사용하여 필요한 초기화 작업 수행
            // 예: title.Text = ContentModel.Title;

            Loaded += Diary_Loaded;
        }

        DiaryViewModels diaryViewModel = new DiaryViewModels();

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

        string dateTime = DateTime.Now.ToString("yyyy.MM.dd.dddd");

        private void Diary_Loaded(object sender, RoutedEventArgs e)
        {
            if (ContentModel != null)
            {
                content_title.Text = ContentModel.ContentName; // ContentModel의 제목을 표시
                genre.Text = ContentModel.Genre;
                date.Text = dateTime;

                // 이미지 URL을 BitmapImage로 변환하여 Image 컨트롤에 할당
                if (!string.IsNullOrEmpty(ContentModel.ImgUrl))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(ContentModel.ImgUrl, UriKind.Absolute);
                    bitmap.EndInit();
                    content_img.Source = bitmap;
                }
            }
            else
            {
                MessageBox.Show("ContentModel is null.");
            }
        }

        private bool IsWrite()
        {
            if(content.Text=="")
            {
                MessageBox.Show("일기를 작성해주세요.");
                return false;
            }
            return true;
        }

        private void Write_Click(object sender, RoutedEventArgs e)
        {
            string diaryContent = content.Text;
            string contentDate = date.Text;
            int star = filledStarCount;
            int contentPK = Convert.ToInt32(ContentModel.PK);
            int userPk = Convert.ToInt32(((App)Application.Current).UserPK);

            if (IsWrite())
            {
                diaryContent = content.Text;
                contentDate = date.Text;
                star = filledStarCount;
                contentPK = Convert.ToInt32(ContentModel.PK);
                userPk = Convert.ToInt32(((App)Application.Current).UserPK);

                DiaryModel diaryModel = new DiaryModel
                {
                    Content = diaryContent,
                    DateTime = contentDate,
                    Star = star,
                    ContentPk = contentPK,
                    UserPk = userPk
                };

                diaryViewModel.Write_Click(diaryModel, ContentModel, NavigationService);


            }
        }

        private void content_GotFocus(object sender, RoutedEventArgs e)
        {
            if (content.Text == "일기를 자유롭게 작성해주세요.")
            {
                content.Text = string.Empty;
                content.Foreground = Brushes.Black;
            }
        }

        private void content_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(content.Text))
            {
                content.Text = "일기를 자유롭게 작성해주세요.";
                content.Foreground = Brushes.Gray;
            }
        }
    }
}
