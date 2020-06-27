using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusinessLayer.Model
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int Cartid { get; set; }
        public int ProductId { get; set; }
        public int Userid { get; set; }
        public int Quantity { get; set; }
        
    }
}