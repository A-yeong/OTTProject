using System.Configuration;
using System.Data;
using System.Windows;

namespace OTTProject
{
  
    public partial class App : Application
    {
        public int? UserPK { get; set; }

        public bool IsUserLoggedIn()
        {
            return UserPK.HasValue;
        }
    }

}
