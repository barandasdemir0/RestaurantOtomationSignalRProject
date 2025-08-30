using Project.EntityLayer.Concrete;

namespace Project.Api.Models
{
    public class ResultBasketListWithProducts
    {
        public int BasketID { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductCount { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
        public string? ProductName { get; set; }
    }
}
