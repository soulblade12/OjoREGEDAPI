using OjoREGEDAPI.BLL.DTOs;
using OjoREGEDAPI.BO;

namespace OjoREGEDAPI.BLL.Interfaces
{
    public interface IAddressBLL
    {
        Task<Task> AddAddressEmp(EmployeeLocationCreateDTO employee_Location);
        Task<IEnumerable<Address>> GetAddressByID(int id);
        Task<Task> AddAddressCust(AddressAddCustomer addresscustomer);
    }
}
