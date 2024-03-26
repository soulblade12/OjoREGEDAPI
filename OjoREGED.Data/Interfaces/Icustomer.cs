using OjoREGEDAPI.BO;


namespace OjoREGEDAPI.Data;

public interface Icustomer : Icrud<Customer>
{
    Task<Task> addCustomer(Customer datacustomer);
    Task<Customer> GetcustomerByID(int id);

    Task<Customer> Login(string Username, string password);

    Task<Task> AddBooking(OrderPlacedSP orderplaced);


    Task<IEnumerable<OrderPlaced>> GetOrderByCustomer(int id);

}
