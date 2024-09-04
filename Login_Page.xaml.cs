using MaterialDesignThemes.Wpf;
using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using WPFModernVerticalMenu.Pages;

namespace WPFModernVerticalMenu
{
    public partial class Login_Page : Window
    {
        public Login_Page()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            // Add password and username for database 
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
