using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DtoLayer.ProductDto
{
    public class ResultProductWithCategory
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductImageUrl { get; set; }
        public bool ProductStatus { get; set; }

        public string? CategoryCategoryName { get; set; }// işte bu kısmı sonradan ekledik çünkü include ile birbirne bağladık ve bu bilgilerin yanında bu da lazım oldu

       
    }
}
