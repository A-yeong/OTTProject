using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.Models
{
    class ContentsModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        private int? pk;
        private string content_name;
        private string img_url;
        private string synopsis;
        private string genre;
        private string ott;

        public int? PK
        {

            get { return pk; }
            set
            {
                pk = value;
                OnPropertyChanged(nameof(pk));
            }
        }

        public string ContentName
        {
            get { return content_name; }
            set
            {
                content_name = value;
                OnPropertyChanged(nameof(ContentName));
            }
        }

        public string ImgUrl
        {
            get { return img_url; }
            set
            {
                content_name = value;
                OnPropertyChanged(nameof(ImgUrl));
            }
        }

        public string Synopsis
        {
            get { return synopsis; }
            set
            {
                content_name = value;
                OnPropertyChanged(nameof(Synopsis));
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                content_name = value;
                OnPropertyChanged(nameof(Genre));
            }
        }

        public string Ott
        {
            get { return ott; }
            set
            {
                content_name = value;
                OnPropertyChanged(nameof(Ott));
            }
        }
    }
}
