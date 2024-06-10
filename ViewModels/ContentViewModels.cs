using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OTTProject.Core;
using OTTProject.Models;
using System.Windows.Navigation;
using System.Security.Policy;
using System.Windows;
using OTTProject.Views;

namespace OTTProject.ViewModels
{
    class ContentViewModels
    {
        ContentsRepository conRepo = new ContentsRepository();

        public ContentsModel SearchContents(string title)
        {
            ContentsModel contents = conRepo.SearchContents(title);
            // MessageBox.Show(contents.PK.ToString());
            return contents;
        }

        public void FindContentByUrl(string url, NavigationService navigationService)
        {
            ContentsModel contents = conRepo.FindContentByUrl(url);
            SearchPage searchPage = new SearchPage
            {
                ContentModel = contents
            };
            navigationService?.Navigate(searchPage);
         
        }
    }

    
}