using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OjoREGEDAPI.BO;

[Table("Role")]
public partial class Role
{
    [Key]
    [Column("Role_ID")]
    public int RoleId { get; set; }

    [Column("Role_Name")]
    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("Role")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
