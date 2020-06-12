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
        public DataTable GetProductDetail()
        {
            SqlCommand cmd = GetCommand("spGetProduct");
            cmd.CommandType = CommandType.StoredProcedure;
            var data = GetCommandDataTable(cmd);
            string ma= Convert.ToString(data.Columns["Product_Name"]);
            int asa = data.Rows.Count;
            return GetCommandDataTable(cmd);
        }

        public bool InsertProduct(ProductDetails productDetails)
        {
            SqlCommand cmd = GetCommand("spInsertProduct");
            cmd.Parameters.AddWithValue("@Product_Name", productDetails.Product_Name);
            cmd.Parameters.AddWithValue("@Product_Description", productDetails.Product_Description);
            cmd.Parameters.AddWithValue("@Quantity", productDetails.Quantity);
            cmd.Parameters.AddWithValue("@Image", productDetails.Image);
            cmd.Parameters.AddWithValue("@Strike_Cost", productDetails.Strike_Cost);
            cmd.Parameters.AddWithValue("@Product_Cost", productDetails.Product_Cost);
            cmd.Parameters.AddWithValue("@Main_Category", productDetails.Main_Category);
            cmd.Parameters.AddWithValue("@Sub_Category", productDetails.Sub_Category);
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected > 0 ? true : false;
        }
    }
}
