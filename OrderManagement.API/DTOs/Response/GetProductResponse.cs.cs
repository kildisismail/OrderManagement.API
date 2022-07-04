namespace OrderManagement.API.DTOs.Response
{
    public class GetProductResponse
    {
        public string BarcodeNumber { get; set; }

        public string Description { get; set; }

        public double Price { get; set;}
    }
}
