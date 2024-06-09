using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OTTProject.Core;
using OTTProject.Models;
using System.Windows.Navigation;
using System.Security.Policy;

namespace OTTProject.ViewModels
{
    class ContentViewModels
    {
        ContentsRepository conRepo = new ContentsRepository();

        public ContentsModel SearchContents(string title)
        {
            ContentsModel contents = conRepo.SearchContents(title);
            return contents;
        }
    }

    
}