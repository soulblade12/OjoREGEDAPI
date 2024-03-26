using OjoREGEDAPI.BO;

namespace OjoREGEDAPI.BLL.DTOs
{
    public class CustomerLoginDTO
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public int SubscriptionId { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public int Role_ID { get; set; }

        public Role Role { get; set; }


    }
}
