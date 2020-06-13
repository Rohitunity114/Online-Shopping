using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    [Table("Products")]
    public class ProductDetails
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int StrikeCost { get; set; }
        public int ProductCost { get; set; }
        public int MainCategory { get; set; }
        public int SubCategory { get; set; }
    }

    [Table("AdminLogin")]
    public class AdminLogin
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
