namespace OrderManagement.API.DTOs.Resquest
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
    }
}
