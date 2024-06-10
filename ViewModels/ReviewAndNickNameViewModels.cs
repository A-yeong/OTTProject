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

    }
}
