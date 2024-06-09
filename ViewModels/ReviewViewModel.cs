using OTTProject.Core;
using OTTProject.Models;
using OTTProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace OTTProject.ViewModels
{
    internal class ReviewViewModel
    {
        ReviewRepository repo = new ReviewRepository();

        public void createReview(ReviewModel reviewModel, ContentsModel contentModel,NavigationService navigationService) {
            repo.CreateReview(reviewModel);
            SearchPage searchPage = new SearchPage
            {
                ContentModel = contentModel
            };
            navigationService?.Navigate(searchPage);

        }

        public void deleteReview(ReviewModel reviewModel) {
            repo.DeleteReview(reviewModel);
        }
    }
}
