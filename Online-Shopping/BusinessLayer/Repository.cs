using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Model;

namespace BusinessLayer
{
    class Repository:BaseRepository
    {
        public bool InsertProduct(ProductDetails productDetails)
        {
            SqlCommand cmd = GetCommand("spInsertProduct");
            cmd.Parameters.AddWithValue("@Product_Name", productDetails.ProductName);
            cmd.Parameters.AddWithValue("@Product_Description", productDetails.ProductDescription);
            cmd.Parameters.AddWithValue("@Quantity", productDetails.Quantity);
            cmd.Parameters.AddWithValue("@Image", productDetails.Image);
            cmd.Parameters.AddWithValue("@Strike_Cost", productDetails.StrikeCost);
            cmd.Parameters.AddWithValue("@Product_Cost", productDetails.ProductCost);
            cmd.Parameters.AddWithValue("@Main_Category", productDetails.MainCategory);
            cmd.Parameters.AddWithValue("@Sub_Category", productDetails.SubCategory);
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected > 0 ? true : false;
        }

        public bool AdminAuthentication(string UserName,string Password)
        {
            SqlCommand cmd = GetCommand("spAuthenticateUser");
            SqlParameter paraName = new SqlParameter("@UserName", UserName);
            SqlParameter paraPassword = new SqlParameter("@Password", Password);

            cmd.Parameters.Add(paraName);
            cmd.Parameters.Add(paraPassword);
            
            int ReturnCode = (int)cmd.ExecuteScalar();
            con.Close();
            return ReturnCode == 1;

        }
    }
}
