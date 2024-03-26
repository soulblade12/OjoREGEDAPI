using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Subcriptions_Level")]
public partial class SubcriptionsLevel
{
    [Key]
    [Column("Subscription_ID")]
    public int SubscriptionId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [InverseProperty("Subscription")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
