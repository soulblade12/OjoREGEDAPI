using OjoREGED.BLL.DTOs;

namespace OjoREGED.BLL.Interfaces
{
    public interface ISubscriptionBLL
    {
        Task<IEnumerable<SubscriptionLevelDTO>> GetAllSubs();

        Task<Task> UpdateSubscription(SubscriptionUpdate subs);
    }
}
