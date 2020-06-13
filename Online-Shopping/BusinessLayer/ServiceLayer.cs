using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ServiceLayer
    {
        private Repository repository;

        public ServiceLayer()
        {
            repository = new Repository();
        }
        public bool InsertProduct(ProductDetails productDetails)
        {
            return repository.InsertProduct(productDetails);
        }        
        
        public bool AdminAuthentications(string userName,string Password)
        {
            return repository.AdminAuthentication(userName, Password);
        }
    }
}
