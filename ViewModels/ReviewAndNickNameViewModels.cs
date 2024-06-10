using OTTProject.Core;
using OTTProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.ViewModels
{
    internal class ReviewAndNickNameViewModels
    {
        private ReviewRepository reviewRepo = new ReviewRepository();
        private Repository repo = new Repository();


        //컨텐츠별 후기 보기
        public List<ReviewAndNickNameModel> ReviewList(int? contentPk)
        {
            List<ReviewModel> reviews = reviewRepo.GetReviewsByContentPk(contentPk);
            List<ReviewAndNickNameModel> reviewAndNickNameList = new List<ReviewAndNickNameModel>();
            
            foreach (ReviewModel value in reviews)
            {
                int starCount = value.Star;
                string starcount = "";
                for(int i =0; i< starCount; i++)
                {
                    starcount += "★";
                }
                UsersModel users = repo.FindNickName(value.UserPk);
                ReviewAndNickNameModel reviewAndNickNameModel = new ReviewAndNickNameModel
                {
                    PK = value.PK,
                    UserPk = value.UserPk,
                    ContentPk = value.ContentPk,

                    StrStarCount = starcount,
                    Content = value.Content,
                    Nickname = users.NickName,

                };

                reviewAndNickNameList.Add(reviewAndNickNameModel);
            }
            return reviewAndNickNameList;
        }

        //사용자별 후기 보기
        public List<ReviewAndNickNameModel> ReviewListByUser()
        {
            List<ReviewModel> reviews = reviewRepo.GetReivesByUser();
            List<ReviewAndNickNameModel> reviewAndNickNameList = new List<ReviewAndNickNameModel>();

            foreach (ReviewModel value in reviews)
            {
                int starCount = value.Star;
                string starcount = "";
                for (int i = 0; i < starCount; i++)
                {
                    starcount += "★";
                }
                UsersModel users = repo.FindNickName(value.UserPk);
                ReviewAndNickNameModel reviewAndNickNameModel = new ReviewAndNickNameModel
                {
                    PK = value.PK,
                    UserPk = value.UserPk,
                    ContentPk = value.ContentPk,

                    StrStarCount = starcount,
                    Content = value.Content,
                    Nickname = users.NickName,

                };

                reviewAndNickNameList.Add(reviewAndNickNameModel);
            }
            return reviewAndNickNameList;
        }
    }
}
