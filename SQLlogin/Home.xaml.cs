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
using System.Xml.Linq;

namespace SQLlogin
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        string user;
        UpdatePage updatePage;
        DeletePage deletePage;
        public Home(string username)
        {
            InitializeComponent();
            user = username;
            txtblock.Text =$"Welcome Mr.{username}";
            updatePage=new UpdatePage(username);
            deletePage=new DeletePage(username);
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            framemain.Content = updatePage;
            
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            framemain.Content = deletePage;
        }
    }
}
