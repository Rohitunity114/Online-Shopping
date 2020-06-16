
using BusinessLayer;
using BusinessLayer.Model;
using Microsoft.TeamFoundation.Dashboards.WebApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;

namespace Online_Shopping.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        [Authorize]
        // GET: Admin/Product
        public ActionResult ViewProduct(int? page)
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from Products", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<ProductDetails> model = new List<ProductDetails>();
                while(rdr.Read())
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
                return View(model.ToPagedList(page ?? 1,2));
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddProduct(ProductDetails productDetails)
        {
            ServiceLayer serviceLayer = new ServiceLayer();
            serviceLayer.InsertProduct(productDetails);
            return RedirectToAction("AddProduct");
        }
       
        public ActionResult UpdateProduct(int id)
        {
            
            DataTable dt = new DataTable();
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Products where ProductId=@ProductId", cn);
                cmd.Parameters.AddWithValue("@ProductId", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
               
                da.Fill(ds);
                return View(ds);
            }
        }

        [HttpPost]
        public ActionResult UpdateProduct(ProductDetails productDetails)
        {
            ServiceLayer serviceLayer = new ServiceLayer();
            serviceLayer.UpdateProduct(productDetails);
            return RedirectToAction("AddProduct");
        }




        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(string UserName,string Password)
        {

            ServiceLayer serviceLayer = new ServiceLayer();
            bool str = serviceLayer.AdminAuthentications(UserName, Password);
            if (str)
            {
                FormsAuthentication.SetAuthCookie(UserName, false);
                return RedirectToAction("Index","Admin");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return RedirectToAction("AdminLogin");
            }

        }
        public ActionResult AdminLogout()
        {
            FormsAuthentication.SignOut();
            return View("AdminLogin");
        }
    }

   
}