
using OjoREGEDAPI.BO;

namespace OjoREGEDAPI.Data
{
    public interface Iemployee : Icrud<Employee>
    {
        Task<Task> AddUser(Employee employee);
        Task<Employee> GetEmpByID(int id);
        Task<IEnumerable<Employee>> GetByID(int id);
        Task<IEnumerable<EmployeeSchedule>> GetEmployee_SchedulesByID(int id);
        Task<IEnumerable<Employee>> GetAllEmployeeData();
        Task<Task> EmpSchedule(EmployeeSchedule employee_Schedule);
        Task<Task> AddPickup(PickupSP pickup);
        Task<IEnumerable<EmployeeSchedule>> GetOrderPlacedByID(int id);
        Task<Employee> Login(string Username, string password);
        Task<IEnumerable<Pickup>> BillsByEmployeeID(int id);
        Task<Task> UpdateOrder(int OrderID);
        Task<Employee> UpdateEmployee(int id, Employee entity);
    }
}
