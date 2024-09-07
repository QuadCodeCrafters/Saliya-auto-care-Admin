using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Windows;

namespace WPFModernVerticalMenu
{
    public class DataBaseConnection
    {
        //Stores all the external connections. such as databases.
        public MySqlConnection con = null;
        public void dDbConnect()
        {
            try
            {
                string connString = "server=localhost;uid=root;pwd=raveen007;database=autocarebase";
                con = new MySqlConnection();
                con.ConnectionString = connString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
