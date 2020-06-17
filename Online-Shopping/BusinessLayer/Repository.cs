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
            cmd.Parameters.AddWithValue("@ProductName", productDetails.ProductName);
            cmd.Parameters.AddWithValue("@ProductDescription", productDetails.ProductDescription);
            cmd.Parameters.AddWithValue("@Quantity", productDetails.Quantity);
            cmd.Parameters.AddWithValue("@Image", productDetails.Image);
            cmd.Parameters.AddWithValue("@StrikeCost", productDetails.StrikeCost);
            cmd.Parameters.AddWithValue("@ProductCost", productDetails.ProductCost);
            cmd.Parameters.AddWithValue("@MainCategory", productDetails.MainCategory);
            cmd.Parameters.AddWithValue("@SubCategory", productDetails.SubCategory);
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected > 0 ? true : false;
        }

        public bool UpdateProduct(ProductDetails productDetails)
        {
            SqlCommand cmd = GetCommand("spUpdateProduct");
            cmd.Parameters.AddWithValue("@productId", productDetails.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", productDetails.ProductName);
            cmd.Parameters.AddWithValue("@ProductDescription", productDetails.ProductDescription);
            cmd.Parameters.AddWithValue("@Quantity", productDetails.Quantity);
            cmd.Parameters.AddWithValue("@Image", productDetails.Image);
            cmd.Parameters.AddWithValue("@StrikeCost", productDetails.StrikeCost);
            cmd.Parameters.AddWithValue("@ProductCost", productDetails.ProductCost);
            cmd.Parameters.AddWithValue("@MainCategory", productDetails.MainCategory);
            cmd.Parameters.AddWithValue("@SubCategory", productDetails.SubCategory);
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected > 0 ? true : false;
        }
        public bool DeleteProduct(int id)
        {
            SqlCommand cmd = GetCommand("spDeleteProduct");
            cmd.Parameters.AddWithValue("@ProductId", id);
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
