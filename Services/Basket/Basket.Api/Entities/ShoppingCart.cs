using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            
        }

        public ShoppingCart(string username)
        {
            UserName = username;
        }
        public string UserName { get; set; }
        public List<ShoppingCartItem>Items { get; set; }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Quantity * item.Price;
                }

                return totalPrice;

            }
        }
    }
}
