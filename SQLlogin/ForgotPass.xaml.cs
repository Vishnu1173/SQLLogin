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
using System.Windows.Shapes;

namespace SQLlogin
{
    /// <summary>
    /// Interaction logic for ForgotPass.xaml
    /// </summary>
    public partial class ForgotPass : Window
    {
        
        public ForgotPass()
        {
            InitializeComponent();
              
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {         
                SqlConnection ocon = new SqlConnection();
                ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
                ocon.Open();//connect                        
                string logincheck = $"Update Sathish Set Password='{txtconfirm.Text}' where SName='{txtname.Text}'";
                SqlCommand sqlc = new SqlCommand(logincheck, ocon);
                int value = sqlc.ExecuteNonQuery();            
            if (value == 1)
            {
                MessageBox.Show("Update Success");
            }             
        }
    }
}
