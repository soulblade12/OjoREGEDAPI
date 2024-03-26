

using OjoREGEDAPI.BO;
using OjoREGEDAPI.Data.Interfaces;

namespace OjoREGEDAPI.Data
{
    public class AddressData : Iaddress
    {
        private readonly AppDbContext _context;

        public AddressData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Task> AddAddressCust(Address addresscustomer)
        {
            try
            {
                await _context.Addresses.AddAsync(addresscustomer);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;

            }
            catch (Exception ex)
            {

                throw new ArgumentException($"{ex.Message}");
            }
        }

        public async Task<Task> AddAddressEmp(EmployeeLocation employee_Location)
        {
            try
            {
                await _context.EmployeeLocations.AddAsync(employee_Location);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;

            }


            catch (Exception ex)
            {
                throw new ArgumentException($"{ex.Message}");
            }
        }

        public Task<Task> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAddressByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Task> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Insert(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
