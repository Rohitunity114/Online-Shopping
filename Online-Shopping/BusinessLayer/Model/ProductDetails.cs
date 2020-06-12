using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class ProductDetails
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Description { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int Strike_Cost { get; set; }
        public int Product_Cost { get; set; }
        public int Main_Category { get; set; }
        public int Sub_Category { get; set; }
    }
}
