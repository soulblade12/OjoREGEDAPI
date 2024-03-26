using AutoMapper;
using OjoREGEDAPI.BLL.DTOs;
using OjoREGEDAPI.BLL.Interfaces;
using OjoREGEDAPI.BO;
using OjoREGEDAPI.Data.Interfaces;

namespace OjoREGEDAPI.BLL
{
    public class AddressBLL : IAddressBLL
    {
        private readonly Iaddress _address;
        private readonly IMapper _mapper;
        public AddressBLL(Iaddress add, IMapper mapper)
        {

            _address = add;
            _mapper = mapper;
        }

        public async Task<Task> AddAddressCust(AddressAddCustomer addresscustomer)
        {
            try
            {
                var addAddress = _mapper.Map<Address>(addresscustomer);
                await _address.AddAddressCust(addAddress);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Task> AddAddressEmp(EmployeeLocationCreateDTO employee_Location)
        {
            try
            {
                var addAddress = _mapper.Map<EmployeeLocation>(employee_Location);
                await _address.AddAddressEmp(addAddress);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IEnumerable<Address>> GetAddressByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
