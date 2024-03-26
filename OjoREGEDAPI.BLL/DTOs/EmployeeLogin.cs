using System.ComponentModel.DataAnnotations;

namespace OjoREGEDAPI.BLL.DTOs
{
    public class EmployeeLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
