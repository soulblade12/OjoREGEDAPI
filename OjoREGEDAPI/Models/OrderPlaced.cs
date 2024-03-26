using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Order_Placed")]
public partial class OrderPlaced
{
    [Key]
    [Column("Order_ID")]
    public int OrderId { get; set; }

    [Column("Time_Placed", TypeName = "datetime")]
    public DateTime TimePlaced { get; set; }

    [Column("Customer_ID")]
    public int CustomerId { get; set; }

    [Column("Employee_Schedule_ID")]
    public int EmployeeScheduleId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("OrderPlaceds")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("EmployeeScheduleId")]
    [InverseProperty("OrderPlaceds")]
    public virtual EmployeeSchedule EmployeeSchedule { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [InverseProperty("Order")]
    public virtual ICollection<Pickup> Pickups { get; set; } = new List<Pickup>();
}
