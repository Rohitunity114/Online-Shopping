using BusinessLayer.Model;
using Microsoft.VisualStudio.Services.DelegatedAuthorization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ServiceLayer:DbContext
    {
        public DbSet<ProductDetails> productDetails { get; set; }

        private Repository repository;

        public ServiceLayer()
        {
            repository = new Repository();
        }
        public bool InsertProduct(ProductDetails productDetails)
        {
            return repository.InsertProduct(productDetails);
        }  
        
        public bool UpdateProduct(ProductDetails productDetails)
        {
            return repository.UpdateProduct(productDetails);
        }

        public bool DeleteProduct(int id)
        {
            return repository.DeleteProduct(id);
        }

        public bool AdminAuthentications(string userName,string Password)
        {
            return repository.AdminAuthentication(userName, Password);
        }

        public bool UserAuthentications(string Email,string Password)
        {
            return repository.UserAuthentication(Email, Password);
        }
    }
}
