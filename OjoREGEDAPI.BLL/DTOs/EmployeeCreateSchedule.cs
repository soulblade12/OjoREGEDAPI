namespace OjoREGEDAPI.BLL.DTOs
{
    public class EmployeeCreateSchedule
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxOrder { get; set; }
        public int EmployeeId { get; set; }
    }
}
