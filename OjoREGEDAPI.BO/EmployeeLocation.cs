using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OjoREGEDAPI.BO;

[Table("Employee_Location")]
public partial class EmployeeLocation
{
    [Key]
    [Column("Employee_Loc_ID")]
    public int EmployeeLocId { get; set; }

    [StringLength(50)]
    public string Province { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [Column("Location_Address")]
    [StringLength(50)]
    public string LocationAddress { get; set; } = null!;

    [Column("Modified_Date", TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; } = DateTime.Now;

    [Column("Employee_ID")]
    public int EmployeeId { get; set; }

    [Column("Postal_Code")]
    [StringLength(50)]
    public string PostalCode { get; set; } = null!;

    [StringLength(50)]
    public string? Longitude { get; set; }

    [StringLength(10)]
    public string? Latitude { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmployeeLocations")]
    public virtual Employee Employee { get; set; } = null!;
}
