using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.Models
{
    internal class DiaryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        private int? pk;
        private string content;
        private string dateTime;
        private int star;
        private int contentPk;
        private int userPk;

        public int? Pk
        {
            get { return pk; }
            set
            {
                pk = value;
                OnPropertyChanged(nameof(pk));
            }

        }

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged(nameof(content));
            }

        }

        public string DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged(nameof(dateTime));
            }

        }

        public int Star
        {
            get { return star; }
            set
            {
                star = value;
                OnPropertyChanged(nameof(star));
            }

        }
        public int ContentPk
        {
            get { return contentPk; }
            set
            {
                contentPk = value;
                OnPropertyChanged(nameof(contentPk));
            }

        }

        public int UserPk
        {
            get { return userPk; }
            set
            {
                userPk = value;
                OnPropertyChanged(nameof(userPk));
            }

        }
    }
}
