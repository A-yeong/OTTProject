using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Controls;
using System.Windows.Navigation;
using OTTProject.ViewModels;
using OTTProject.Models;

namespace OTTProject.Views
{
    /// <summary>
    /// SearchPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            Loaded += SearchPage_Loaded;
        }

        public string TitleQuery { get; set; }
        public ContentsModel model { get; set; }

        private void SearchPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

            string titleTxt = title.Text;
            if (!string.IsNullOrEmpty(TitleQuery))
            {
                title.Text = titleTxt;
                // content_img.Source = model.ImgUrl;
                genre.Text = model.Genre;
                synopsis.Text = model.Synopsis;
            }
        }
    }
}
