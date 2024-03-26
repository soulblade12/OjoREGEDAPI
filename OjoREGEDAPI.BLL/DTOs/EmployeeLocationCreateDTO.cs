namespace OjoREGEDAPI.BLL.DTOs
{
    public class EmployeeLocationCreateDTO
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string LocationAddress { get; set; }
        public int EmployeeId { get; set; }
        public string PostalCode { get; set; }
    }
}
