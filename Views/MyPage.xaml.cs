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
        private DiaryTitleAndContentViewModel diaryTitleAndContentViewModel = new DiaryTitleAndContentViewModel();
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
        }

        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DiaryTitleAndContentViewModel diaryModel = (DiaryTitleAndContentViewModel)button.Tag;
            // 여기서부터 작성해야됨
            // diaryModel.deleteDiary(reviewModel, ContentModel, NavigationService);
        }

        public void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DiaryTitleAndContentModel diaryModel = (DiaryTitleAndContentModel)button.Tag;

            string title = diaryModel.Title;
            MessageBox.Show(title);

            //if (diaryModel.PK.HasValue)
            //{
            //    DiaryModel diary = diaryTitleAndContentViewModel.getDiary(diaryModel.PK.Value);

            //    ContentsModel contentModel = new ContentsModel
            //    {
            //        PK = diary.ContentPk,
            //        ContentName = diaryModel.Title,
            //    };

            //    Diary diaryPage = new Diary(contentModel);
            //    NavigationService.Navigate(diaryPage);
            //}
            //else
            //{
            //    MessageBox.Show("Invalid diary entry.");
            //}
        }

    }
}
