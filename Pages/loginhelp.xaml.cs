using System;
using System.Media;
using System.Windows;

namespace WPFModernVerticalMenu.Pages
{
    public partial class loginhelp : Window
    {
        public loginhelp()
        {
            InitializeComponent();
            this.Deactivated += Loginhelp_Deactivated;
            this.Topmost = true;
        }

        private void Loginhelp_Deactivated(object sender, EventArgs e)
        {
             
            this.Topmost = true;
            this.Activate();
        }

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

         
        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            PlayClickSound();
        }

         
        protected override void OnMouseRightButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseRightButtonDown(e);
            PlayClickSound();
        }
 
        protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.ChangedButton == System.Windows.Input.MouseButton.Middle)
            {
                PlayClickSound();
            }
        }

         
        private void PlayClickSound()
        {
            SystemSounds.Beep.Play();
        }
    }
}
