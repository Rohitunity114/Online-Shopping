using BusinessLayer.Model;
using System.Data.Entity;

namespace BusinessLayer
{
    public class ServiceLayer:DbContext
    {
        public DbSet<ProductDetails> productDetails { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Registration> registrations { get; set; }
        public DbSet<ViewCart> viewCarts { get; set; }
        
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

        public bool InsertCart(Cart cart)
        {
            return repository.AddCart(cart);
        }

        public bool GetCart(int id)
        {
            return repository.GetCartDetail(id);
        }
        public int GetUserId(string Email)
        {
            return repository.GetUserId(Email);
        }

        public System.Data.Entity.DbSet<BusinessLayer.Model.ViewCart> ViewCarts { get; set; }
    }
}
