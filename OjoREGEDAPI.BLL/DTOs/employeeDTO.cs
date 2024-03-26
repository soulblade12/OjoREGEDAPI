namespace OjoREGEDAPI.BLL.DTOs
{
    public class employeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public RoleDTO Role { get; set; }
        public ICollection<EmployeeLocationDTO> EmployeeLocations { get; set; }
        public ICollection<EmployeeScheduleDTO> EmployeeSchedules { get; set; }
    }
}
