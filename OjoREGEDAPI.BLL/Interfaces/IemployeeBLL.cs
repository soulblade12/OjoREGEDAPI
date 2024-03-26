

using OjoREGEDAPI.BLL.DTOs;

namespace OjoREGED.BLL.Interfaces
{
    public interface IemployeeBLL
    {
        Task<employeeDTO> EmployeeLogin(EmployeeLogin employee);
        Task<Task> Insertemployee(CreateEmployeeDTO employee);
        IEnumerable<employeeDTO> GetAllEmployee();
        IEnumerable<EmployeeScheduleDTO> GetAllEmployeeSchedule();
        Task<employeeDTO> GetEmployeesByID(int id);
        void Update(employeeDTO employee);
        Task<Task> UpdateOrderStatus(int OrderID);
        IEnumerable<employeeDTO> GetDataEmployee();
        Task<Task> EmpSchedule(EmployeeCreateSchedule employee_Schedule);
        Task<Task> AddPickup(EmployeeInsertPickup pickup);
        Task<IEnumerable<Employee_OrderPlacedDTO>> GetEmployee_OrderPlacedDTOs(int id);
        Task<IEnumerable<PickupDTO>> GetPickups(int id);

        Task<Task> UpdateEmployee(EmployeeUpdateDTO emp);


        void Delete(int id);
    }
}
