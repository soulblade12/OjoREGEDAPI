using AutoMapper;
using OjoREGED.BLL.DTOs;
using OjoREGED.BLL.Interfaces;
using OjoREGEDAPI.Data;

namespace OjoREGEDAPI.BLL
{
    public class SubscriptionBLL : ISubscriptionBLL
    {

        private readonly Isubscription _subs;
        private readonly IMapper _mapper;
        public SubscriptionBLL(Isubscription subs, IMapper mapper)
        {

            _subs = subs;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SubscriptionLevelDTO>> GetAllSubs()
        {
            var customer = await _subs.GetAll();
            var customerDTO = _mapper.Map<IEnumerable<SubscriptionLevelDTO>>(customer);
            return customerDTO;
        }

        public async Task<Task> UpdateSubscription(SubscriptionUpdate subs)
        {
            var articleInserted = await _subs.UpdateSubscription(subs.Subscription_ID, subs.Customer_ID);
            return Task.CompletedTask;
        }
    }
}
