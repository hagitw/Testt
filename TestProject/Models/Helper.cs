using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class Helper
    {
        static public string GetConnection()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=C:\Users\USER\source\repos\TestProject\TestProject\App_Data\DB.mdf;
Integrated Security=True;";
        }
    }
}