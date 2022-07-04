namespace OrderManagement.API.DTOs.Resquest
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string? BarcodeNumber { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public double Price { get; set; }
    }
}
