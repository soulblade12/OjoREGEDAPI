using OjoREGEDAPI.BO;

namespace OjoREGEDAPI.Data.Interfaces
{
    public interface Iaddress : Icrud<Address>
    {
        Task<Task> AddAddressEmp(EmployeeLocation employee_Location);
        Task<IEnumerable<Address>> GetAddressByID(int id);
        Task<Task> AddAddressCust(Address addresscustomer);
    }
}
