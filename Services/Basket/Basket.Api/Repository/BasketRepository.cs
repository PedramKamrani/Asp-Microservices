using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Basket.Api.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.Api.Repository
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IDistributedCache _cache;

        public BasketRepository(IDistributedCache cache)
        {
            _cache = cache; 
        }
        public async Task<ShoppingCart> GetBasket(string userName)
        {
           var result= await _cache.GetStringAsync(userName);
           if (result == null)
               return null;
           return JsonSerializer.Deserialize<ShoppingCart>(result);


        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            //var basketUser =await GetBasket(basket.UserName);
            var basketSerialize = JsonSerializer.Serialize(basket);
           await _cache.SetStringAsync(basket.UserName, basketSerialize);
           //await _cache.SetStringAsync(basketUser.UserName, basketSerialize);
           return basket;
        }

        public async Task DeleteBasket(string userName)
        {
            await _cache.RemoveAsync(userName);
        }
    }
}
