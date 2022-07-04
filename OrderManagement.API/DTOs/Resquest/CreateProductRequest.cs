
namespace OrderManagement.API.DTOs.Resquest
{
    public class CreateProductRequest
    {
        public string BarcodeNumber { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
