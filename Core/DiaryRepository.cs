using MySqlConnector;
using OTTProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTTProject.Core
{
    internal class DiaryRepository
    {
        private MySqlConnection conn;

        public DiaryRepository()
        {
            string connString = "Server=localhost;Uid=root;Database=ott;Port=3306;Pwd=1234";
            conn = new MySqlConnection(connString);
        }

        public ContentsModel ContentModel { get; set; }
    }
}
