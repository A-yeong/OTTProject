using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.Models
{
    internal class DiaryTitleAndContentModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }

        private int? pk;
        private int? contentPk;
        private string? title;
        private string? content;

        public int? PK
        {
            get { return pk; }
            set
            {
                pk = value;
                OnPropertyChanged(nameof(pk));
            }
        }

        public int? ContentPK
        {
            get { return contentPk; }
            set
            {
                contentPk = value;
                OnPropertyChanged(nameof(contentPk));
            }
        }


        public string? Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(title));
            }
        }

        public string? Content
        {
            get { return content; }
            set
            {
                content = value;
                OnPropertyChanged(nameof(content));
            }
        }
    }
}
