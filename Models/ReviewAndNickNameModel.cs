using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Converters;

namespace OTTProject.Models
{
    internal class ReviewAndNickNameModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
        private int? pk;
        private int? contentPk;
        private int? userPk;
        private string strStarCount;
        private string content;
        private string nickName;
        private bool? canEdit;
        private bool? canDelete;

        public int? PK
        {
            get { return pk; }
            set {
                pk = value;
                OnPropertyChanged(nameof(pk));
            }
        }

        public int? ContentPk
        {
            get { return contentPk; }
            set {
                contentPk = value;
                OnPropertyChanged(nameof(contentPk));
            }
        }

        public int? UserPk {
            get { return userPk; }
            set {
                userPk = value;
                OnPropertyChanged(nameof(userPk));
            }
        }

        public string StrStarCount
        {
            get { return strStarCount; }
            set {
                strStarCount = value;
                OnPropertyChanged(nameof(strStarCount));
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

        public string Nickname
        {
            get { return nickName; }
            set {
                nickName = value;
                OnPropertyChanged(nameof(nickName));
            }
        }

        public bool? CanEdit
        {
            get { return canEdit; }
            set {
                canEdit = value;
                OnPropertyChanged(nameof(canEdit));
            }
        }
        
        public bool? CanDelete {

            get { return canDelete; }
            set {
                canDelete = value;
                OnPropertyChanged(nameof(canDelete));
            }
        }
    }

}
