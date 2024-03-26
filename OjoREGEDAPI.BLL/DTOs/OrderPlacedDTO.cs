namespace OjoREGEDAPI.BLL.DTOs
{
    public class OrderPlacedDTO
    {
        public int OrderId { get; set; }
        public DateTime TimePlaced { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeScheduleId { get; set; }


        public ICollection<OrderDetailsDTO> OrderDetails { get; set; }

    }
}
