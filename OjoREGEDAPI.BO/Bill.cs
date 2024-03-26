using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OjoREGEDAPI.BO;

public partial class Bill
{
    [Key]
    [Column("Bills_ID")]
    public int BillsId { get; set; }

    [Column("Tip_Amount", TypeName = "money")]
    public decimal TipAmount { get; set; }

    [Column("Pickup_ID")]
    public int PickupId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime BillDate { get; set; }

    [Column("Customer_ID")]
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Bills")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("PickupId")]
    [InverseProperty("Bills")]
    public virtual Pickup Pickup { get; set; } = null!;
}
