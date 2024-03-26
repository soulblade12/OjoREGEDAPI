using System.ComponentModel.DataAnnotations;
namespace OjoREGEDAPI.BLL.DTOs
{
    public class CustomerLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
