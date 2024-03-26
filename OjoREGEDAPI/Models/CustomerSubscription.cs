using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Customer_Subscription")]
public partial class CustomerSubscription
{
    [Key]
    [Column("Customer_SubsID")]
    public int CustomerSubsId { get; set; }

    [Column("Customer_ID")]
    public int CustomerId { get; set; }

    [Column("Start_Date", TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column("End_Date", TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CustomerSubscriptions")]
    public virtual Customer Customer { get; set; } = null!;
}
