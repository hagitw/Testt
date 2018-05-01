using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.DAL
{
    public class Helper
    {
        public static  string GetConnection()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\USER\source\repos\TestProject\TestProject\App_Data\DB.mdf;
Integrated Security=True;";
        }
    }
}