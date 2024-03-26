namespace OjoREGEDAPI.BLL.DTOs
{
    public class PickupDTO
    {
        public int PickupId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime PickupTime { get; set; }
        public string DeliveryStatus { get; set; }
        public int OrderId { get; set; }

        public ICollection<BillDTO> Bills { get; set; }

    }
}
