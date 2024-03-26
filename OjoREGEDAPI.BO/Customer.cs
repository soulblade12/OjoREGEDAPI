using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OjoREGEDAPI.BO;

[Table("Customer")]
public partial class Customer
{
    [Key]
    [Column("Customer_ID")]
    public int CustomerId { get; set; }

    [Column("First_Name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("Middle_Name")]
    public string? MiddleName { get; set; }

    [Column("Last_Name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]

    public string Telephone { get; set; } = null!;

    [Column("Subscription_ID")]
    public int SubscriptionId { get; set; } = 1;

    [Column("Email_Address")]
    [StringLength(255)]
    public string EmailAddress { get; set; } = null!;

    [StringLength(50)]
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    [Column("Role_ID")]
    public int? RoleId { get; set; } = 2;

    [StringLength(50)]
    public string? Image { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    [InverseProperty("Customer")]
    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    [InverseProperty("Customer")]
    public virtual ICollection<CustomerSubscription> CustomerSubscriptions { get; set; } = new List<CustomerSubscription>();

    [InverseProperty("Customer")]
    public virtual ICollection<OrderPlaced> OrderPlaceds { get; set; } = new List<OrderPlaced>();

    [ForeignKey("RoleId")]
    [InverseProperty("Customers")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("SubscriptionId")]
    [InverseProperty("Customers")]
    public virtual SubcriptionsLevel Subscription { get; set; } = null!;
}
