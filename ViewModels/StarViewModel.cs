﻿using OTTProject.Core;
using OTTProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.ViewModels
{
    internal class StarViewModel
    {
        StarRepository starRepo = new StarRepository();
        ContentsRepository contentsRepo = new ContentsRepository();
        public StarModel GetStarModel(int? contentPk) {

            StarModel model = starRepo.GetStar(contentPk);
            return model;
        }

        public void CreateStar(int? contentPk) {
            starRepo.CreateStar(contentPk);
        }

        public void DeleteStar(StarModel starModel) {
            starRepo.DeleteStar(starModel);
        }
        
        //관심작품 10개만 
        public List<string> starContentByUser() {
            List<string> imgUrls = new List<string>();
            List<StarModel> stars = starRepo.StarByUser();
            foreach (StarModel value in stars) {
                ContentsModel contentModel = contentsRepo.ContentByPk(value.ContentPk);
                imgUrls.Add(contentModel.ImgUrl);
            }
            return imgUrls;
        }
        //관심작품 모두 가져오기
        public List<string> starContentByUserAll() {
            List<string> imgUrls = new List<string>();
            List<StarModel> stars = starRepo.StarByUserAll();
            foreach (StarModel value in stars)
            {
                ContentsModel contentModel = contentsRepo.ContentByPk(value.ContentPk);
                imgUrls.Add(contentModel.ImgUrl);
            }
            return imgUrls;
        }
    }
}
