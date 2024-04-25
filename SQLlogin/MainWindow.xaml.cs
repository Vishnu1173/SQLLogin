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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
            Regist regist = new Regist();
            regist.Show();  
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

            //sqlconnection
            SqlConnection ocon = new SqlConnection();
            ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
            ocon.Open();//connect                        
            //string logincheck = $"Select count(*) from sathish where SName='{txtname.Text}' And Password='{txtpassword.Text}'";
            string logincheck = $"Select SName from sathish where SName='{txtname.Text}' And Password='{txtpassword.Text}'";
            SqlCommand sqlc = new SqlCommand(logincheck, ocon);
            object value1 = sqlc.ExecuteScalar();
            string username=value1.ToString();
            //int count=Convert.ToInt32(value);
            //if (count > 0)
            if (!string.IsNullOrEmpty(username)) 
            {
                Home home=new Home(username);
                //home.txtblock.Text = $"Welcome Mr.{txtname.Text}";
                home.Show();
            }
             
            ocon.Close();
        }

        private void btnrest_Click(object sender, RoutedEventArgs e)
        {             
                ForgotPass forgotPass = new ForgotPass();
                forgotPass.Show();
             
        }
    }
}
