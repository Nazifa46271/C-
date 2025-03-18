using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodWord
{
     class sqlcon
    {
       // MySqlConnection con = new MySqlConnection("server = 127.0.0.1; database = foodhub; username = root; password= Admin@1234; ");

        public static readonly string con_String = "server = 127.0.0.1; database = foodhub; username = root; password= Admin@1234;";
        public static MySqlConnection con = new MySqlConnection(con_String);

    }
}
