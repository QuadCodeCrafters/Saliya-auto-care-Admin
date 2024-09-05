using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Windows.Media.Animation;

namespace WPFModernVerticalMenu
{
    /// <summary>
    /// Interaction logic for Login_Page.xaml
    /// </summary>
    public partial class Login_Page : Window
    {
        DataBaseConnection d1 = null;
        public Login_Page(DataBaseConnection obj)
        {
            InitializeComponent();
            d1 = obj;
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtusername.Text =="" || txtpassword.Password == "")
            {
                if(txtusername.Text == "")
                {
                    accError.Text = "Please fill the user name";
                }
                if(txtpassword.Password == "")
                {
                    accError.Text = "Please fill the password";
                }
                if(txtusername.Text == "" && txtpassword.Password == "")
                {
                    accError.Text = "Please fill user name and the password";
                }
               
            }
            else
            {
                //add password and username for database
                string usName = txtusername.Text,pass = txtpassword.Password;
                 d1.con.Open();
                string query = "SELECT UserName,password FROM useraccounts WHERE UserName = @v1 AND password = @v2";
                MySqlCommand cmd = new MySqlCommand(query, d1.con);
                cmd.Parameters.AddWithValue("@v1",usName);
                cmd.Parameters.AddWithValue("@v2",pass);
                MySqlDataReader reader = cmd.ExecuteReader();
                string us = "";
                string pas = "";
                while (reader.Read())
                {
                     us = reader.GetString("UserName");
                     pas = reader.GetString("password");
                }
                if(us != "" && pas != "")
                {
                     MainWindow m1 = new MainWindow();
                     this.Hide();
                     m1.Show();
                }
                else
                {
                    accError.Text = "Incorrect user name or password";
                }
                d1.con.Close();
            }
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();
        private void themetoggle_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletteHelper.GetTheme();

            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }

            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }

            paletteHelper.SetTheme(theme);
        }
    }
}
