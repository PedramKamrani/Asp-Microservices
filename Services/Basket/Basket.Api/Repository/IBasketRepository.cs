﻿using Basket.Api.Entities;
using System.Threading.Tasks;

namespace Basket.Api.Repository
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}
