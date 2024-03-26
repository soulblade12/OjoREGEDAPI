using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Pickup")]
public partial class Pickup
{
    [Key]
    [Column("Pickup_ID")]
    public int PickupId { get; set; }

    [Column("Employee_ID")]
    public int EmployeeId { get; set; }

    [Column("Pickup_Time", TypeName = "datetime")]
    public DateTime PickupTime { get; set; }

    [Column("Delivery_Status")]
    [StringLength(50)]
    public string DeliveryStatus { get; set; } = null!;

    [Column("Order_ID")]
    public int OrderId { get; set; }

    [InverseProperty("Pickup")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    [ForeignKey("EmployeeId")]
    [InverseProperty("Pickups")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("Pickups")]
    public virtual OrderPlaced Order { get; set; } = null!;
}
