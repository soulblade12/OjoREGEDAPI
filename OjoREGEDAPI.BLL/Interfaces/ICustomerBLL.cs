using OjoREGED.BLL.DTOs;
using OjoREGEDAPI.BLL.DTOs;

namespace OjoREGED.BLL.Interfaces
{
    public interface ICustomerBLL
    {
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<Task> InsertCustomer(CustomerCreateDTO Customer);
        Task<int> AddAddress(AddressesDTO addresscustomer);
        Task<CustomerLoginDTO> CustomerLogin(CustomerLogin customerLogin);
        Task<CustomerDTO> CustomerGetByID(int id);
        IEnumerable<AddressesDTO> AddressGetByID(int id);
        Task<IEnumerable<OrderPlacedDTO>> custGetOrderByCustomeromergetbyid(int id);
        Task<Task> AddBooking(InsertBookingSP insertbook);


    }
}
