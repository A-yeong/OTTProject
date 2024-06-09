using OTTProject.Core;
using OTTProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.ViewModels
{
    internal class ReviewViewModel
    {
        ReviewRepository repo = new ReviewRepository();

        public void createReview(ReviewModel reviewModel) {
            repo.CreateReview(reviewModel);

        }

        public void deleteReview(ReviewModel reviewModel) {
            repo.DeleteReview(reviewModel);
        }
    }
}
