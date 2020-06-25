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
        public bool AddCart(Cart cart)
        {
            SqlCommand cmd = GetCommand("GetAddCart");
            cmd.Parameters.AddWithValue("@ProductId", cart.ProductId);
            cmd.Parameters.AddWithValue("@Userid", cart.Userid);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);

            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected > 0 ? true : false;
        }
        public int GetUserId(string Email)
        {
            SqlCommand cmd = GetCommand("spGetUserId");
            cmd.Parameters.AddWithValue("@Email", Email);            
            int id = (int)cmd.ExecuteScalar();
            con.Close();
            return id;
        }

        public bool GetCartDetail(int id)
        {
            SqlCommand cmd = GetCommand("GetCartDetails");
            cmd.Parameters.AddWithValue("@Userid", id);
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

        public bool UserAuthentication(string Email,string Password)
        {
            SqlCommand cmd = GetCommand("spUserLogin");
            SqlParameter paraEmail = new SqlParameter("@Email", Email);
            SqlParameter paraPassword = new SqlParameter("@Password", Password);

            cmd.Parameters.Add(paraEmail);
            cmd.Parameters.Add(paraPassword);

            int rowAffected = (int)cmd.ExecuteScalar();
            con.Close();
            return rowAffected > 0 ? true : false;
        }
    }
}
