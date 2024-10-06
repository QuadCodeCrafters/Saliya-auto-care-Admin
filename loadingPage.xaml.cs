using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;

namespace WPFModernVerticalMenu
{
    /// <summary>
    /// Interaction logic for loadingPage.xaml
    /// </summary>
    public partial class loadingPage : Window
    {
        DataBaseConnection d1 = new DataBaseConnection();
        public loadingPage()
        {
            InitializeComponent();
            d1.dDbConnect();
        }
        
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker bk = new BackgroundWorker();
            bk.WorkerReportsProgress = true;
            bk.DoWork += bk_DoWork;
            bk.ProgressChanged += bk_ProgressChanged;
            bk.RunWorkerAsync();
        }
        void bk_DoWork(object sender, EventArgs e)
        {
            //A Thread for Run the Loading
            for (int i = 0; i <= 50; i++)
            {

                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(50);
            }
        }

        void bk_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            ProgressBar.Value = e.ProgressPercentage;
            if (ProgressBar.Value == 50)
            {
                Login_Page lP = new Login_Page(d1);
                lP.Show();
                this.Close();
            }

        }
    }
}

