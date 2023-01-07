using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{
    public class DiscountProfiler : Profile
    {
        public DiscountProfiler()
        {
            CreateMap<CouponModel, Coupon>().ReverseMap();
        }
    }
}
