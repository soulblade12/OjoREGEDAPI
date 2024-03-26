using Microsoft.EntityFrameworkCore;
using OjoREGEDAPI.BO;

namespace OjoREGEDAPI.Data
{
    public class EmployeeData : Iemployee
    {
        private readonly AppDbContext _context;
        public EmployeeData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Task> AddPickup(PickupSP pickup)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Check if the provided order ID is valid
                    if (pickup.Order_ID == null)
                    {
                        throw new InvalidOperationException("Order ID cannot be NULL.");
                    }

                    // Get the OrderDetailID and CustomerID for the provided order ID
                    var orderDetail = await _context.OrderPlaceds
                        .Include(od => od.OrderDetails)
                        .Where(od => od.OrderId == pickup.Order_ID && od.OrderDetails.Any(od => od.OrderStatus == 3))
                        .FirstOrDefaultAsync();

                    if (orderDetail == null)
                    {
                        throw new InvalidOperationException("Invalid order ID or no orders available for pickup.");
                    }

                    var customerID = orderDetail.CustomerId;
                    var orderDetailID = orderDetail.OrderDetails.FirstOrDefault()?.OrderDetailId;

                    // Update order status to indicate pickup
                    orderDetail.OrderDetails.Any(od => od.OrderStatus == 2);
                    await _context.SaveChangesAsync();

                    // Insert pickup record
                    var pickups = new Pickup
                    {
                        EmployeeId = pickup.Employee_ID,
                        PickupTime = DateTime.Now,
                        DeliveryStatus = pickup.Delivery_Status,
                        OrderId = pickup.Order_ID
                    };
                    _context.Pickups.Add(pickups);
                    await _context.SaveChangesAsync();

                    var pickupID = pickups.PickupId;

                    // Insert bill record
                    var bill = new Bill
                    {
                        CustomerId = customerID,
                        TipAmount = pickup.Tip_Amount,
                        PickupId = pickupID,
                        BillDate = DateTime.Now
                    };
                    _context.Bills.Add(bill);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public async Task<Task> AddUser(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Pickup>> BillsByEmployeeID(int id)
        {
            var result = await _context.Pickups.Include(c => c.Bills).Where(c => c.EmployeeId == id).ToListAsync();
            return result;
        }

        public Task<Task> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> EmpSchedule(EmployeeSchedule employee_Schedule)
        {
            try
            {
                // Check if the employee exists
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee_Schedule.EmployeeId);
                if (employee == null)
                {
                    throw new InvalidOperationException("Invalid EmployeeID cannot be inserted.");
                }

                // Create a new EmployeeSchedule entity
                var employeeSchedule = new EmployeeSchedule
                {
                    EmployeeId = employee_Schedule.EmployeeId,
                    Status = "Kosong", // Assuming "Kosong" is the default status
                    StartDate = employee_Schedule.StartDate,
                    EndDate = employee_Schedule.EndDate,
                    MaxOrder = employee_Schedule.MaxOrder,
                    OrderScheduled = 0 // Assuming OrderScheduled starts from 0
                };

                // Add the EmployeeSchedule entity to the context and save changes
                _context.EmployeeSchedules.Add(employeeSchedule);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllEmployeeData()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Task> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetEmpByID(int id)
        {
            var result = await _context.Employees
                .Include(Address => Address.EmployeeLocations)
                .Include(EmployeeSchedule => EmployeeSchedule.EmployeeSchedules)
                .FirstOrDefaultAsync(customer => customer.EmployeeId == id);
            return result;
        }

        public async Task<IEnumerable<EmployeeSchedule>> GetEmployee_SchedulesByID(int id)
        {
            var result = await _context.EmployeeSchedules.Where(c => c.EmployeeId == id).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<EmployeeSchedule>> GetOrderPlacedByID(int id)
        {
            var result = await _context.EmployeeSchedules.Include(c => c.OrderPlaceds).ThenInclude(o => o.OrderDetails)
            .ThenInclude(c => c.OrderStatusNavigation).Where(c => c.EmployeeId == id).ToListAsync();
            return result;
        }

        public Task<Task> Insert(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Login(string Username, string password)
        {
            var login = await _context.Employees.Include(r => r.Role).Where(u => u.Username == Username && u.Password == password).SingleOrDefaultAsync();
            return login;
        }

        public Task<Task> Update(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> UpdateEmployee(int id, Employee entity)
        {
            var updateEmp = await GetEmpByID(id);
            if (updateEmp == null)
            {
                throw null;
            }
            updateEmp.FirstName = entity.FirstName;
            updateEmp.MiddleName = entity.MiddleName;
            updateEmp.LastName = entity.LastName;
            updateEmp.Telephone = entity.Telephone;
            //articleID.CategoryId = entity.CategoryId;
            await _context.SaveChangesAsync();
            return updateEmp;
        }

        public async Task<Task> UpdateOrder(int OrderID)
        {
            var orderDetail = await _context.OrderPlaceds
    .Include(od => od.OrderDetails) // Include the OrderPlaced navigation property
    .Where(od => od.OrderId == OrderID)
    .SingleOrDefaultAsync();

            if (orderDetail != null)
            {
                foreach (var od in orderDetail.OrderDetails)
                {
                    od.OrderStatus = 3;
                }
                await _context.SaveChangesAsync();
            }
            return Task.CompletedTask;
        }

    }
}
