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

namespace OTTProject
{
    
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            // 회원가입 버튼 클릭 시 페이지를 변경하거나 네비게이션하는 로직을 작성합니다.
            // 예를 들어, 다른 페이지로 네비게이션할 수 있습니다.
            NavigationService.Navigate(new Uri("Views/SignIn.xaml", UriKind.Relative));
        }
    }

}
