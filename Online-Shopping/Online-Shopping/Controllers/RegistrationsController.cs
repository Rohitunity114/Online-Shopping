using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Model;
using Online_Shopping.Models;

namespace Online_Shopping.Controllers
{
    public class RegistrationsController : Controller
    {
        string connectionString = @"server=.; initial catalog=OnlineShopping; integrated security=true";

        [HttpGet]
        public ActionResult UserRegistration()
        {
            return View(new Registration());
        }

        [HttpPost]
        public ActionResult UserRegistration(Registration regi)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("spRegistration", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", regi.FirstName);
                cmd.Parameters.AddWithValue("@Lastname", regi.LastName);
                cmd.Parameters.AddWithValue("@Mobile", regi.Mobile);
                cmd.Parameters.AddWithValue("@Email", regi.Email);
                cmd.Parameters.AddWithValue("@Password", regi.Password);
                cmd.Parameters.AddWithValue("@ConfirmPassword", regi.ConfirmPassword);
                cmd.Parameters.AddWithValue("@Address", regi.Address);
                cmd.Parameters.AddWithValue("@ProfileImage", regi.ProfileImage);
                cmd.Parameters.AddWithValue("@City", regi.City);
                cmd.Parameters.AddWithValue("@State", regi.State);

                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("UserRegistration");
        }

        public ActionResult ViewProduct()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceLayer"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Products", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<ProductDetails> model = new List<ProductDetails>();
                while (rdr.Read())
                {

                    var detail = new ProductDetails();
                    detail.ProductId = Convert.ToInt32(rdr["ProductId"].ToString());
                    detail.ProductName = rdr["ProductName"].ToString();
                    detail.ProductDescription = rdr["ProductDescription"].ToString();
                    detail.Quantity = Convert.ToInt32(rdr["Quantity"].ToString());
                    detail.Image = rdr["Image"].ToString();
                    detail.StrikeCost = Convert.ToInt32(rdr["StrikeCost"].ToString());
                    detail.ProductCost = Convert.ToInt32(rdr["ProductCost"].ToString());
                    detail.MainCategory = Convert.ToInt32(rdr["MainCategory"].ToString());
                    detail.SubCategory = Convert.ToInt32(rdr["SubCategory"].ToString());

                    model.Add(detail);
                }
                return View(model);
            }
        }
    }
}