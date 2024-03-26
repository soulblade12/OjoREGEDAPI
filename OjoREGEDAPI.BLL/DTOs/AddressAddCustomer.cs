namespace OjoREGEDAPI.BLL.DTOs
{
    public class AddressAddCustomer
    {
        public int CustomerId { get; set; }
        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
    }
}
