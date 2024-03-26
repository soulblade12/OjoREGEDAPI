namespace OjoREGEDAPI.BLL.DTOs
{
    public class AddressesDTO
    {
        //public int Address_ID { get; set; }
        //public int Customer_ID { get; set; }
        //public string Province { get; set; }
        //public string City { get; set; }
        //public string Street_Address { get; set; }
        //public string Postal_Code { get; set; }
        //public DateTime Modified_Date { get; set; }
        public int CustomerId { get; set; }
        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string PostalCode { get; set; } = null!;


    }
}
