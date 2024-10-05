using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MySql.Data.MySqlClient;
using System.Windows.Threading;
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
            if (txtusername.Text == "" && txtpassword.Password == "")
            {
                accError.Text = "Please fill in the required fields";
            }
            else if (txtusername.Text == "")
            {
                accError.Text = "Please fill the Username";
                ShowUsernameErrorAnimation();
            }
            else if (txtpassword.Password == "")
            {
                accError.Text = "Please fill the password";
                ShowPasswordErrorAnimation();
            }
            else
            {
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
                d1.con.Close();

                if (us != "" && pas != "")
                {
                    MainWindow m1 = new MainWindow();
                    this.Hide();
                    m1.Show();
                }
                else
                {
                    accError.Text = "Incorrect username or password";
                    ShowUsernameErrorAnimation();
                    ShowPasswordErrorAnimation();
                }
            }
        }

        private void ShowUsernameErrorAnimation()
        {
            txtusername.BorderBrush = Brushes.Red;

            TranslateTransform translateTransform = new TranslateTransform();
            txtusername.RenderTransform = translateTransform;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 10,
                Duration = TimeSpan.FromMilliseconds(50),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(5) // Shake 5 times
            };

            translateTransform.BeginAnimation(TranslateTransform.XProperty, animation);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (s, e) =>
            {
                txtusername.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFDDDDDD"); // Reset to default border color
                timer.Stop();
            };
            timer.Start();
        }

        private void ShowPasswordErrorAnimation()
        {
            txtpassword.BorderBrush = Brushes.Red;

            TranslateTransform translateTransform = new TranslateTransform();
            txtpassword.RenderTransform = translateTransform;

            DoubleAnimation animation = new DoubleAnimation
            {
                From = 0,
                To = 10,
                Duration = TimeSpan.FromMilliseconds(50),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(5) // Shake 5 times
            };

            translateTransform.BeginAnimation(TranslateTransform.XProperty, animation);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += (s, e) =>
            {
                txtpassword.BorderBrush = (Brush)new BrushConverter().ConvertFromString("#FFDDDDDD");
                timer.Stop();
            };
            timer.Start();
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

   
        private void txtusername_TextChanged(object sender, TextChangedEventArgs e)
        {
            accError.Text = ""; // Clear the error message TextChanged property on xaml
        }
         
        private void txtpassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            accError.Text = ""; // Clear the error message TextChanged property on xaml
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
                // Add middle-click behavior if needed
            }
        }

        private void PlayClickSound()
        {
            // Add code to play a sound on click (optional)
        }
    }
}
