using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Order_Status")]
public partial class OrderStatus
{
    [Key]
    [Column("Order_Status")]
    public int OrderStatus1 { get; set; }

    [Column("Status_Description")]
    [StringLength(50)]
    public string StatusDescription { get; set; } = null!;

    [InverseProperty("OrderStatusNavigation")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
