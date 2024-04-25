using Microsoft.Data.SqlClient;
using SQLlogin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace SQLlogin.Business
{
    public class DataHelper : Common
    {
        public DataHelper() 
        {
        }
        //public string SetUsers(string username, string password, string email)
        //{
        //    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
        //    {
        //        return "All The Value is Required,Please Enter The Value";
        //    }
        //    else
        //    {
        //        Query = $"Insert Into Sathish Values('{username}','{password}','{email}')";
        //        //insert,update,delete,drop
        //        int output = ExcuteQuery();//common class used
        //        if (output > 0)
        //        {
        //            return ("Register Success");
        //        }
        //        return ("Register Failed");
        //    }
        //}
    }
}
