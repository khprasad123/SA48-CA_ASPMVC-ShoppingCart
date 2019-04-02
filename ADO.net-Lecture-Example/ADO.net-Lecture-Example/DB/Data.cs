using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Serves as the Data Layer
namespace ViewClasses.DB
{
    public class Data
    {
        // Change the SERVER Name to what is shown on your SQL Server Management Studio
        public static string connectionString = "Server=DESKTOP-11U091P\\SQLEXPRESS;" +
                "Database=issDemo; Integrated Security=true";
    }
}