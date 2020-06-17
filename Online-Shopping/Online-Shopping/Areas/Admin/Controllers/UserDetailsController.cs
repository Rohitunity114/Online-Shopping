using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Online_Shopping.Models;
using BusinessLayer;

namespace Online_Shopping.Areas.Admin.Controllers
{
    public class UserDetailsController : Controller
    {      
        [Authorize]
        // GET: Admin/UserDetails
        public ActionResult UserDetails()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ServiceLayer"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Registration", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                List<Registration> rigi = new List<Registration>();
                while (rdr.Read())
                {
                    var details = new Registration();
                    details.Userid = Convert.ToInt32(rdr["Userid"].ToString());
                    details.FirstName = rdr["FirstName"].ToString();
                    details.LastName = rdr["LastName"].ToString();
                    details.Mobile = Convert.ToInt64(rdr["Mobile"].ToString());
                    details.Email = rdr["Email"].ToString();
                    details.Password = rdr["Password"].ToString();
                    details.ConfirmPassword = rdr["ConfirmPassword"].ToString();
                    details.Address = rdr["Address"].ToString();
                    details.ProfileImage = rdr["ProfileImage"].ToString();
                    details.City = rdr["City"].ToString();
                    details.State = rdr["State"].ToString();

                    rigi.Add(details);
                }
                return View(rigi);
            }

        }       
    }
}