using BookAndShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndShop.Services.BasketService
{
    public interface IBasketService
    {
        void AddBasketItem(int id);
        void AddBasketItem(Book book);
        void Clear();
        Task<List<BasketItem>> GetBasketItems();
        void RemoveBasketItem(int id);
        void RemoveAllCountBasketItem(int Id);
        void RemoveAllBasketItems();
    }
}
