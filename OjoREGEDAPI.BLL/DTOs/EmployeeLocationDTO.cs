namespace OjoREGEDAPI.BLL.DTOs
{
    public class EmployeeLocationDTO
    {

        public string Province { get; set; } = null!;
        public string City { get; set; } = null!;
        public string LocationAddress { get; set; } = null!;
        public int EmployeeId { get; set; }
        public string PostalCode { get; set; } = null!;
    }
}
