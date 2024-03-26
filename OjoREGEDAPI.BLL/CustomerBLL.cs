using AutoMapper;
using OjoREGED.BLL.DTOs;
using OjoREGED.BLL.Interfaces;
using OjoREGEDAPI.BLL.DTOs;
using OjoREGEDAPI.BO;
using OjoREGEDAPI.Data;

namespace OjoREGEDAPI.BLL
{
    public class CustomerBLL : ICustomerBLL
    {
        private readonly Icustomer _customerData;
        private readonly IMapper _mapper;
        public CustomerBLL(Icustomer customer, IMapper mapper)
        {

            _customerData = customer;
            _mapper = mapper;
        }
        public Task<int> AddAddress(AddressesDTO addresscustomer)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> AddBooking(InsertBookingSP insertbook)
        {
            var custBook = _mapper.Map<OrderPlacedSP>(insertbook);
            var articleInserted = await _customerData.AddBooking(custBook);
            return Task.CompletedTask;
        }

        public IEnumerable<AddressesDTO> AddressGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderPlacedDTO>> custGetOrderByCustomeromergetbyid(int id)
        {
            var loginuser = await _customerData.GetOrderByCustomer(id);
            var loginMAP = _mapper.Map<IEnumerable<OrderPlacedDTO>>(loginuser);
            return loginMAP;
        }

        public async Task<CustomerDTO> CustomerGetByID(int id)
        {
            var customer = await _customerData.GetcustomerByID(id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return customerDTO;
        }

        public async Task<CustomerLoginDTO> CustomerLogin(CustomerLogin customerLogin)
        {
            var Password = Helper.GetHash(customerLogin.Password);
            var loginuser = await _customerData.Login(customerLogin.Username, Password);
            var loginMAP = _mapper.Map<CustomerLoginDTO>(loginuser);
            return loginMAP;
        }

        public async Task<IEnumerable<CustomerDTO>> GetAll()
        {
            var customer = await _customerData.GetAll();
            var customerDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customer);
            return customerDTO;
        }

        public async Task<Task> InsertCustomer(CustomerCreateDTO Customer)
        {
            var Password = Helper.GetHash(Customer.Password);
            Customer.Password = Password;
            var map = _mapper.Map<Customer>(Customer);
            var add = await _customerData.addCustomer(map);
            return Task.FromResult(add);
        }
    }
}
