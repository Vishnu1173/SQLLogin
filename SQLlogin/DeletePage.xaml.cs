using Microsoft.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace SQLlogin
{
    /// <summary>
    /// Interaction logic for DeletePage.xaml
    /// </summary>
    public partial class DeletePage : Page
    {
        string user;
        public DeletePage(string username)
        {
            InitializeComponent();
            user= username;
        }

        private void btnyes_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection ocon = new SqlConnection();
            ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
            ocon.Open();//connect                        
            string logincheck = $"Delete from Sathish where SName ='{user}'";
            SqlCommand sqlc = new SqlCommand(logincheck, ocon);
            int value = sqlc.ExecuteNonQuery();
            if (value == 1)
            {
                MessageBox.Show("Delete Success");
            }
            ocon.Close();

        }

        private void btnno_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
        }
    }
}
