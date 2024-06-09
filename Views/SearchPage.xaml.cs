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

        private void SearchPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ContentModel != null)
            {
                MessageBox.Show(ContentModel.PK.ToString());
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
            }
            else
            {
                MessageBox.Show("ContentModel is null.");
            }
        }
    }
}
