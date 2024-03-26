namespace OjoREGEDAPI.BLL.DTOs
{
    public class EmployeeScheduleDTO
    {
        public int EmployeeScheduleID { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MaxOrder { get; set; }
        public int OrderScheduled { get; set; }
    }
}
