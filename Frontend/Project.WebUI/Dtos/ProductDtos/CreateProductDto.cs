namespace Project.WebUI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductImageUrl { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryID { get; set; }

    }
}
