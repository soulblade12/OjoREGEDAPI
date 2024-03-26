using Microsoft.EntityFrameworkCore;
using OjoREGEDAPI.BO;
using System.Data;


namespace OjoREGEDAPI.Data
{
    public class CustomerData : Icustomer
    {
        private readonly AppDbContext _context;

        public CustomerData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Task> AddBooking(OrderPlacedSP orderplaced)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Check if the employee schedule exists
                    var employeeSchedule = _context.EmployeeSchedules.FirstOrDefault(es => es.EmployeeScheduleId == orderplaced.Employee_Schedule_ID);
                    if (employeeSchedule == null)
                    {
                        throw new InvalidOperationException("Invalid EmployeeScheduleID cannot be inserted.");
                    }

                    // Check if the customer exists and has a valid subscription
                    var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == orderplaced.Customer_ID && c.SubscriptionId > 1);
                    if (customer == null)
                    {
                        throw new InvalidOperationException("Invalid customer ID. Please provide a valid customer ID.");
                    }

                    // Check if the customer ID exists in the Address table
                    var customerAddress = _context.Customers
                        .Include(c => c.Addresses)
                        .FirstOrDefault(c => c.CustomerId == orderplaced.Customer_ID);
                    if (customerAddress == null)
                    {
                        throw new InvalidOperationException("Customer ID not found in the Address table.");
                    }

                    // Insert into Order_Placed table
                    var orderPlaced = new OrderPlaced
                    {
                        CustomerId = orderplaced.Customer_ID,
                        EmployeeScheduleId = orderplaced.Employee_Schedule_ID
                    };
                    _context.OrderPlaceds.Add(orderPlaced);
                    await _context.SaveChangesAsync();

                    var orderId = orderPlaced.OrderId;

                    // Update Order_Scheduled in Employee_Schedule table
                    employeeSchedule.OrderScheduled++;
                    await _context.SaveChangesAsync();

                    // Check if the employee schedule is full
                    if (employeeSchedule.OrderScheduled == employeeSchedule.MaxOrder)
                    {
                        employeeSchedule.Status = "Penuh";
                        _context.SaveChanges();
                    }

                    // Insert into Order_Detail table
                    var orderDetail = new OrderDetail
                    {
                        OrderId = orderId,
                        OrderInstruction = orderplaced.Order_Instruction,
                        Size = orderplaced.Size,
                        Weight = orderplaced.Weight
                    };
                    await _context.OrderDetails.AddAsync(orderDetail);
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


        public async Task<Task> addCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<Task> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var result = await _context.Customers.ToListAsync();
            return result;
        }

        public Task<Task> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetcustomerByID(int id)
        {
            var result = await _context.Customers
                .Include(Address => Address.Addresses)
                .Include(customer => customer.Role)
                .FirstOrDefaultAsync(customer => customer.CustomerId == id);
            return result;
        }

        public async Task<IEnumerable<OrderPlaced>> GetOrderByCustomer(int id)
        {
            var result = await _context.OrderPlaceds.Include(o => o.OrderDetails)
                                                    .ThenInclude(c => c.OrderStatusNavigation)
                                                .Where(c => c.CustomerId == id).ToListAsync();
            return result;
        }

        public Task<Task> Insert(Customer entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> Login(string username, string password)
        {
            var login = await _context.Customers.Include(r => r.Role).Where(u => u.Username == username && u.Password == password).SingleOrDefaultAsync();
            return login;
        }

        public Task<Task> Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
