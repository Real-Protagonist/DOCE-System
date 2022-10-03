using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Athena
{
    internal class bridge
    {
        private MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;user='doce';password='5544332211';database='athena_room'");
        
        public MySqlConnection cn()
        {
            return conn;
        }
    }
}
