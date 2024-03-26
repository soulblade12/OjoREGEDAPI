using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Order_Detail")]
public partial class OrderDetail
{
    [Key]
    [Column("OrderDetail_ID")]
    public int OrderDetailId { get; set; }

    [Column("Order_ID")]
    public int OrderId { get; set; }

    [Column(TypeName = "numeric(18, 4)")]
    public decimal Weight { get; set; }

    [StringLength(10)]
    public string Size { get; set; } = null!;

    [Column("Order_Instruction")]
    public string OrderInstruction { get; set; } = null!;

    [Column("Order_Status")]
    public int OrderStatus { get; set; }

    [Column("Order_Img")]
    [Unicode(false)]
    public string? OrderImg { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual OrderPlaced Order { get; set; } = null!;

    [ForeignKey("OrderStatus")]
    [InverseProperty("OrderDetails")]
    public virtual OrderStatus OrderStatusNavigation { get; set; } = null!;
}
