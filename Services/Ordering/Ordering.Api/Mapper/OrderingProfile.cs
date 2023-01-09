using AutoMapper;
using EventBusMessage.Events;
using Ordering.Application.Features.Commands.CheckOutOrder;

namespace Ordering.Api.Mapper
{
    public class OrderingProfile : Profile
    {
        public OrderingProfile()
        {
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }

}

