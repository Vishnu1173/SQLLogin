using System.Data;
using System.Diagnostics.Metrics;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace SQLlogin
{
    /// <summary>
    /// Interaction logic for Regist.xaml
    /// </summary>
    public partial class Regist : Window
    {
        public Regist()
        {
            InitializeComponent();
            SqlConnection ocon = new SqlConnection();
            ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
            ocon.Open();
            string sqlq = "select*from Country";
            SqlCommand sqlc= new SqlCommand(sqlq,ocon);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlc);
            DataSet ds = new DataSet();
            adapter.Fill(ds,"Country");
            cmbcountry.ItemsSource = ds.Tables["Country"].DefaultView;
            cmbcountry.DisplayMemberPath = "CountryName";
            cmbcountry.SelectedValuePath = "Cid";
            ocon.Close();  
        }

        private void btnsave_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtname.Text)|| string.IsNullOrEmpty(txtpassword.Text) || string.IsNullOrEmpty(txtemail.Text))
            {
                MessageBox.Show("All The Value is Required,Please Enter The Value");
            }
            else
            {
                //sqlconnection
                SqlConnection ocon = new SqlConnection();
                ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
                ocon.Open();//connect                
                string registquery="Insert Into Sathish Values(@SName,@Password,@Email)";
                SqlCommand sqlc=new SqlCommand(registquery,ocon);
                sqlc.Parameters.AddWithValue("@SName",txtname.Text);
                sqlc.Parameters.AddWithValue("@Password", txtpassword.Text);
                sqlc.Parameters.AddWithValue("@Email", txtemail.Text);
                int value = sqlc.ExecuteNonQuery();
                if (value == 1)
                {
                    MessageBox.Show("Register Success");
                }
                ocon.Close();
            }

        }

        private void cmbcountry_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {             
            SqlConnection ocon = new SqlConnection();
            ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
            ocon.Open();
            string value=cmbcountry.SelectedValue.ToString();
            string sqlq = "select * from State1 where Cid ="+value;
            SqlCommand sqlc = new SqlCommand(sqlq, ocon);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlc);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "State");
            cmbstate.ItemsSource=null; 
            cmbstate.ItemsSource = ds.Tables["State"].DefaultView;
            cmbstate.DisplayMemberPath = "StateName";
            cmbstate.SelectedValuePath = "Sid";
            ocon.Close();
            
        }

        private void cmbstate_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SqlConnection ocon = new SqlConnection();
            ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
            ocon.Open();
            string value = cmbstate.SelectedValue.ToString();
            string sqlq = "select * from City where Sid =" + value;
            SqlCommand sqlc = new SqlCommand(sqlq, ocon);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlc);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "City");
            cmbcity.ItemsSource = null;
            cmbcity.ItemsSource = ds.Tables["city"].DefaultView;
            cmbcity.DisplayMemberPath = "CityName";
            cmbcity.SelectedValuePath = "Cityid";
            ocon.Close();
        }

        private void cmbcity_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SqlConnection ocon = new SqlConnection();
            ocon.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=OCT05;Data Source=DESKTOP-2MPHQ9B\\SQLEXPRESS;Encrypt=False";
            ocon.Open();
            string value = cmbcity.SelectedValue.ToString();
            string sqlq = "select * from Village where Cityid =" + value;
            SqlCommand sqlc = new SqlCommand(sqlq, ocon);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlc);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Village");
            cmbvillage.ItemsSource = null;
            cmbvillage.ItemsSource = ds.Tables["Village"].DefaultView;
            cmbvillage.DisplayMemberPath = "VillageName";
            cmbvillage.SelectedValuePath = "Vid";
            ocon.Close();
        }
    }
}
