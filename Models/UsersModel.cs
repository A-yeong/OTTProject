using System;
using System.ComponentModel;

namespace OTTProject.Models
{
    internal class UsersModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
        private int? pk;
        private string userName;
        private string id;
        private string pw;
        private string nickName;
        public int? PK {

            get { return pk; }
            set {
                pk = value;
                OnPropertyChanged(nameof(pk));
            }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string PW
        {
            get { return pw; }
            set
            {
                pw = value;
                OnPropertyChanged(nameof(PW));
            }
        }

        public string NickName
        {
            get { return nickName; }
            set
            {
                nickName = value;
                OnPropertyChanged(nameof(NickName));
            }
        }
    }
}
