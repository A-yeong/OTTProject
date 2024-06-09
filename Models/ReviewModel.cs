using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.Models
{
    internal class ReviewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        private int? pk;
        private int contentPk;
        private int userPk;
        private int star;
        private string content;

        public int? Pk
        {
            get { return pk; }
            set {
                pk = value;
                OnPropertyChanged(nameof(pk));
            }

        }

        public int ContentPk {
            get { return contentPk; }
            set {
                contentPk = value;
                OnPropertyChanged(nameof(contentPk));
                }
        }
        public int UserPk
        {
            get { return userPk; }
            set {
                userPk = value;
                OnPropertyChanged(nameof(userPk));
            }
        }
        public int Star
        {
            get { return star; }
            set {
                star = value;
                OnPropertyChanged(nameof(star));
            }
        }

        public string Content
        {
            get { return content; }
            set {
                content = value;
                OnPropertyChanged(nameof(content));
            }
        }


    }
}
