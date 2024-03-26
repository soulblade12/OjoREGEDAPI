namespace OjoREGEDAPI.BLL.DTOs
{
    public class OrderDetailsDTO
    {

        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public decimal Weight { get; set; }
        public string Size { get; set; } = null!;
        public string OrderInstruction { get; set; } = null!;
        public int OrderStatus { get; set; }
        public string? OrderImg { get; set; }

        public OrderStatusDTO OrderStatusNavigation { get; set; }
    }
}
