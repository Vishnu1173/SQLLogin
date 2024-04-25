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

namespace SQLlogin
{
    /// <summary>
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Page
    {
        string user;
        public UpdatePage(string username)
        {
            InitializeComponent();
            user = username;
            username1.Visibility = Visibility.Collapsed;
            txtname.Visibility = Visibility.Collapsed;
        }        
        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
          
            //sqlconnection
            SqlConnection ocon = new SqlConnection();
            ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
            ocon.Open();//connect                        
            string registquery = $"Update Sathish Set  Password='{txtpassword.Text}',Email='{txtemail.Text}' Where SName='{user}'";
            SqlCommand sqlc = new SqlCommand(registquery, ocon);
            int value = sqlc.ExecuteNonQuery();
            if (value == 1)
            {
                MessageBox.Show("Update Success");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
            ocon.Close();
        }
    }
}
