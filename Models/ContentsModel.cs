using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.Models
{
    public class ContentsModel : INotifyPropertyChanged
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
                OnPropertyChanged(nameof(content_name));
            }
        }

        public string ImgUrl
        {
            get { return img_url; }
            set
            {
                img_url = value;
                OnPropertyChanged(nameof(img_url));
            }
        }

        public string Synopsis
        {
            get { return synopsis; }
            set
            {
                synopsis = value;
                OnPropertyChanged(nameof(synopsis));
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged(nameof(genre));
            }
        }

        public string Ott
        {
            get { return ott; }
            set
            {
                ott = value;
                OnPropertyChanged(nameof(ott));
            }
        }
    }
}
