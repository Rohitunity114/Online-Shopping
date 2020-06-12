
using BusinessLayer;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_Shopping.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult ViewProduct()
        {
            ServiceLayer serviceLayer = new ServiceLayer();            
            return View(serviceLayer.GetProductDetails());
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductDetails productDetails)
        {
            ServiceLayer serviceLayer = new ServiceLayer();
            serviceLayer.InsertProduct(productDetails);
            return RedirectToAction("ViewProduct");
        }
    }
}