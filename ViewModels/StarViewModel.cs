using OTTProject.Core;
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
    }
}
