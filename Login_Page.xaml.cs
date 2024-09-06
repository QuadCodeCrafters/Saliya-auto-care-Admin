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
using System.Data.SqlClient;
using WPFModernVerticalMenu.Pages;

namespace WPFModernVerticalMenu
{
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
            if (txtusername.Text == "" || txtpassword.Password == "")
            {
                if (txtusername.Text == "")
                {
                    accError.Text = "Please fill the user name";
                }
                if (txtpassword.Password == "")
                {
                    accError.Text = "Please fill the password";
                }
                if (txtusername.Text == "" && txtpassword.Password == "")
                {
                    accError.Text = "Please fill user name and the password";
                }

            }
            else
            {
                //add password and username for database
                string usName = txtusername.Text, pass = txtpassword.Password;
                d1.con.Open();
                string query = "SELECT UserName,password FROM useraccounts WHERE UserName = @v1 AND password = @v2";
                MySqlCommand cmd = new MySqlCommand(query, d1.con);
                cmd.Parameters.AddWithValue("@v1", usName);
                cmd.Parameters.AddWithValue("@v2", pass);
                MySqlDataReader reader = cmd.ExecuteReader();
                string us = "";
                string pas = "";
                while (reader.Read())
                {
                    us = reader.GetString("UserName");
                    pas = reader.GetString("password");
                }
                if (us != "" && pas != "")
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

        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        private void themetoggle_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception obj)
            {
                MessageBox.Show(obj.Message.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            DisableLoginPageElements();

             
            loginhelp loginhelp = new loginhelp();

            
            loginhelp.Closed += Loginhelp_Closed;

            loginhelp.Show();
        }

        private void Loginhelp_Closed(object sender, EventArgs e)
        {
 
            EnableLoginPageElements();
        }

        private void DisableLoginPageElements()
        {
            txtusername.IsEnabled = false;
            txtpassword.IsEnabled = false;
            btnlogin.IsEnabled = false;
            DialogHost1.IsEnabled = false;
        }

        private void EnableLoginPageElements()
        {
            txtusername.IsEnabled = true;
            txtpassword.IsEnabled = true;
            btnlogin.IsEnabled = true;
            DialogHost1.IsEnabled = true;
        }

       
        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
          
        }

       
        protected override void OnMouseRightButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);
            
        }

       
        protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.ChangedButton == System.Windows.Input.MouseButton.Middle)
            {
                
            }
        }

         
        private void PlayClickSound()
        {
             
        }
    }
}
