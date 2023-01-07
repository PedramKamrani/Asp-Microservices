using System.Threading.Tasks;
using Discount.Grpc.Protos;

namespace Basket.Api.GrpcService
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
        {
            _discountProtoServiceClient = discountProtoServiceClient;
        }

        public async Task<CouponModel> GetDisCount(string productName)
        {
            GetDiscountRequest request = new GetDiscountRequest { ProductName = productName };

            var resx= await _discountProtoServiceClient.GetDiscountAsync(request);
            if (resx == null)
                return new CouponModel();
            return resx;
        }
    }
}
