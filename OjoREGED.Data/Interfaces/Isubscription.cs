using OjoREGEDAPI.BO;

namespace OjoREGEDAPI.Data
{
    public interface Isubscription : Icrud<SubcriptionsLevel>
    {
        Task<Task> UpdateSubscription(int subcriptions_level, int Customer_ID);
    }
}
