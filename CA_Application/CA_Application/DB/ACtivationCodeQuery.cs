using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CA_Application.DB
{
    public class ActivationCodeQuery
    {
        public static List<string> GetActivationCode(string Date,int Productid,string Username) //getting activation code for the order and product
        {
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection(Data.connectionString))
            {
                conn.Open();

                string sql = @"SELECT ActivationCode from OrderActivationCode
                 WHERE DateOfPurchase = '" + Date + "'" + "and ProductId= '" +Productid+ "' and Username='"+Username+"'"; //for checking the hash
                SqlCommand cmd = new SqlCommand(sql, conn); //executing the cammand
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string temp = (string)reader["ActivationCode"];
                    list.Add(temp);
                }
            }

            return list;
        }
    }
}