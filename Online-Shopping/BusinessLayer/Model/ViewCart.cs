using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class ViewCart
    {
        [Key]
        public int id { get; set; }
        public int Userid { get; set; }
        public string ProductName { get; set; }
        public int ProductCost { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
