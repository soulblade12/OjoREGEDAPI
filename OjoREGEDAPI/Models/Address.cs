using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OjoREGEDAPI.Models;

[Table("Address")]
public partial class Address
{
    [Key]
    [Column("Address_ID")]
    public int AddressId { get; set; }

    [Column("Customer_ID")]
    public int CustomerId { get; set; }

    [StringLength(50)]
    public string Province { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [Column("Street_Address")]
    [StringLength(100)]
    public string StreetAddress { get; set; } = null!;

    [Column("Postal_Code")]
    [StringLength(50)]
    public string PostalCode { get; set; } = null!;

    [Column("Modified_Date", TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(50)]
    public string? Longitude { get; set; }

    [StringLength(50)]
    public string? Latitude { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Addresses")]
    public virtual Customer Customer { get; set; } = null!;
}
