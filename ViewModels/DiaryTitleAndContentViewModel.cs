using OTTProject.Core;
using OTTProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.ViewModels
{
    internal class DiaryTitleAndContentViewModel
    {
        private ContentsRepository contentRepo = new ContentsRepository();
        private DiaryRepository diaryRepo = new DiaryRepository();

        public List<DiaryTitleAndContentModel> DiaryList(int? userPk)
        {
            List<DiaryModel> diaries = diaryRepo.GetUserDiary(userPk);
            List<DiaryTitleAndContentModel> diaryAndContentList = new List<DiaryTitleAndContentModel>();

            foreach(DiaryModel value in diaries)
            {
                int contentPk = value.ContentPk;
                DiaryTitleAndContentModel model = new DiaryTitleAndContentModel
                {
                    PK = value.Pk,
                    ContentPK = value.ContentPk,
                    Title = contentRepo.getTitle(contentPk),
                    Content = value.Content
                };

                diaryAndContentList.Add(model);
            }

            return diaryAndContentList;
        }

        public DiaryModel getDiary(int? pk)
        {
            DiaryModel model = diaryRepo.getDiaryModel(pk);
            return model;
        }
    }
}
