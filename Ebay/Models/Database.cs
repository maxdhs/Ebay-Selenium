using System;
using MySql.Data.MySqlClient;
using Ebay;
 
namespace Ebay.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
