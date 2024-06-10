using OTTProject.Core;
using OTTProject.Models;
using OTTProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace OTTProject.ViewModels
{
    internal class DiaryViewModels
    {
        DiaryRepository repo = new DiaryRepository();

        public void Write_Click(DiaryModel diaryModel, ContentsModel contentModel, NavigationService navigationService)
        {
            repo.DiaryWrite(diaryModel);

            MessageBox.Show("일기 작성이 완료되었습니다.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            SearchPage searchPage = new SearchPage
            {
                ContentModel = contentModel
            };
            navigationService?.Navigate(searchPage);
        }

        public void DeleteDiary(int? diaryPk,NavigationService navigationService) {

            repo.DeleteDiary(diaryPk);
            navigationService?.Navigate(new MyPage());
        }

    }
}
