using OjoREGEDAPI.BLL.DTOs;

namespace OjoREGED.BLL.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public int SubscriptionId { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string Image { get; set; }

        public ICollection<AddressesDTO> Addresses { get; set; }
        //public ICollection<Bill> Bills { get; set; }
        //public ICollection<CustomerSubscription> CustomerSubscriptions { get; set; }
        //public ICollection<OrderPlaced> OrderPlaceds { get; set; }
        public RoleDTO Role { get; set; }
        //public SubcriptionsLevel Subscription { get; set; }
    }
}
