using AutoMapper;
using OjoREGED.BLL.Interfaces;
using OjoREGEDAPI.BLL.DTOs;
using OjoREGEDAPI.BO;
using OjoREGEDAPI.Data;

namespace OjoREGEDAPI.BLL
{
    public class EmployeeBLL : IemployeeBLL
    {

        private readonly Iemployee _employeedata;
        private readonly IMapper _mapper;
        public EmployeeBLL(Iemployee employee, IMapper mapper)
        {

            _employeedata = employee;
            _mapper = mapper;
        }


        public async Task<Task> AddPickup(EmployeeInsertPickup pickup)
        {
            var custBook = _mapper.Map<PickupSP>(pickup);
            var articleInserted = await _employeedata.AddPickup(custBook);
            return Task.CompletedTask;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<employeeDTO> EmployeeLogin(EmployeeLogin employee)
        {
            var Password = Helper.GetHash(employee.Password);
            var loginuser = await _employeedata.Login(employee.Username, Password);
            var loginMAP = _mapper.Map<employeeDTO>(loginuser);
            return loginMAP;
        }

        public async Task<Task> EmpSchedule(EmployeeCreateSchedule employee_Schedule)
        {
            var empaddSch = _mapper.Map<EmployeeSchedule>(employee_Schedule);
            var empSchInsert = await _employeedata.EmpSchedule(empaddSch);
            return Task.CompletedTask;
        }

        public IEnumerable<employeeDTO> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeScheduleDTO> GetAllEmployeeSchedule()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<employeeDTO> GetDataEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<employeeDTO> GetEmployeesByID(int id)
        {
            var customer = await _employeedata.GetEmpByID(id);
            var employeeDTO = _mapper.Map<employeeDTO>(customer);
            return employeeDTO;
        }

        public async Task<IEnumerable<Employee_OrderPlacedDTO>> GetEmployee_OrderPlacedDTOs(int id)
        {
            var customer = await _employeedata.GetOrderPlacedByID(id);
            var employeeDTO = _mapper.Map<IEnumerable<Employee_OrderPlacedDTO>>(customer);
            return employeeDTO;
        }

        public async Task<IEnumerable<PickupDTO>> GetPickups(int id)
        {
            var customer = await _employeedata.BillsByEmployeeID(id);
            var employeeDTO = _mapper.Map<IEnumerable<PickupDTO>>(customer);
            return employeeDTO;
        }

        public async Task<Task> Insertemployee(CreateEmployeeDTO employee)
        {
            var Password = Helper.GetHash(employee.Password);
            employee.Password = Password;
            var map = _mapper.Map<Employee>(employee);
            var add = await _employeedata.AddUser(map);
            return Task.FromResult(add);
        }

        public void Update(employeeDTO employee)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> UpdateEmployee(EmployeeUpdateDTO emp)
        {
            var mapCateg = _mapper.Map<Employee>(emp);
            var add = await _employeedata.UpdateEmployee(emp.EmployeeId, mapCateg);
            return Task.FromResult(add);
        }

        public async Task<Task> UpdateOrderStatus(int OrderID)
        {
            await _employeedata.UpdateOrder(OrderID);
            return Task.CompletedTask;
        }
    }
}
