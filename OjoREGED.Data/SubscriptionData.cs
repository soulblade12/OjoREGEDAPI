using Microsoft.EntityFrameworkCore;
using OjoREGEDAPI.BO;

namespace OjoREGEDAPI.Data
{
    public class SubscriptionData : Isubscription
    {
        private readonly AppDbContext _context;

        public SubscriptionData(AppDbContext context)
        {
            _context = context;
        }
        public Task<Task> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubcriptionsLevel>> GetAll()
        {
            var getall = await _context.SubcriptionsLevels.ToListAsync();
            return getall;
        }

        public Task<Task> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Insert(SubcriptionsLevel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Update(SubcriptionsLevel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> UpdateSubscription(int subcriptions_level, int Customer_ID)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var updateArticle = await _context.Customers.SingleOrDefaultAsync(a => a.CustomerId == Customer_ID);
                    if (updateArticle == null)
                    {
                        throw new ArgumentException("Article not found");
                    }
                    updateArticle.SubscriptionId = subcriptions_level;



                    await _context.SaveChangesAsync();

                    // Insert new subscription record
                    var startDate = DateTime.Now;
                    var endDate = startDate.AddMonths(subcriptions_level);
                    var price = await _context.SubcriptionsLevels
                        .Where(s => s.SubscriptionId == subcriptions_level)
                        .Select(s => s.Price)
                        .FirstOrDefaultAsync();
                    var amount = price * (decimal)(endDate - startDate).TotalDays / 30;

                    var customerSubscription = new CustomerSubscription
                    {
                        CustomerId = Customer_ID,
                        StartDate = startDate,
                        EndDate = endDate,
                        Amount = amount
                    };

                    _context.CustomerSubscriptions.Add(customerSubscription);
                    await _context.SaveChangesAsync();

                    transaction.Commit();
                    return Task.CompletedTask;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }
    }
}
