using Project.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project.WebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketID { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductCount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public string?  ProductName { get; set; }
    }
}
