using BookAndShop.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookAndShop.Services.BasketService
{
    public sealed class BasketService : IBasketService
    {
        ProtectedLocalStorage storage;
        List<BasketItem> basketItems = new List<BasketItem>();

        public BasketService(ProtectedLocalStorage storage)
        {
            this.storage = storage;
            //InitializeBasketItems();
        }

        public void AddBasketItem(Book item)
        {
            storage.DeleteAsync("basket");
            var currentBasketItem = basketItems.Where(x => x.BookId == item.Id).FirstOrDefault();
            if (currentBasketItem != null)
            {
                currentBasketItem.Count++;
            }
            else
            {
                basketItems.Add(new BasketItem(item));
            }
            storage.SetAsync("basket", basketItems);
        }

        public void RemoveBasketItem(int Id)
        {
            storage.DeleteAsync("basket");
            var currentBasketItem = basketItems.Where(x => x.BookId == Id).FirstOrDefault();
            if (currentBasketItem.Count == 1)
            {
                basketItems.Remove(currentBasketItem);
            }
            else
            {
                currentBasketItem.Count--;
            }
            storage.SetAsync("basket", basketItems);
        }

        public void RemoveAllCountBasketItem(int Id)
        {
            storage.DeleteAsync("basket");
            var currentBasketItem = basketItems.Where(x => x.BookId == Id).FirstOrDefault();
            basketItems.Remove(currentBasketItem);
            storage.SetAsync("basket", basketItems);
        }

        public void RemoveAllBasketItems()
        {
            storage.DeleteAsync("basket");
            basketItems.Clear();
        }

        public void AddBasketItem(int Id)
        {
            storage.DeleteAsync("basket");
            var currentBasketItem = basketItems.Where(x => x.BookId == Id).FirstOrDefault();
            if (currentBasketItem != null)
            {
                currentBasketItem.Count++;
            }
            storage.SetAsync("basket", basketItems);
        }

        public void Clear()
        {
            storage.DeleteAsync("basket");
            basketItems.Clear();
            storage.DeleteAsync("basket");
        }

        public async Task<List<BasketItem>> GetBasketItems()
        {
            await InitializeBasketItems();
            return basketItems;
        }

        private async Task InitializeBasketItems()
        {
            var result = await storage.GetAsync<List<BasketItem>>("basket");
            basketItems = result.Success ? result.Value : new List<BasketItem>();
        }
    }

    public class BasketItem
    {
        public BasketItem(Book book)
        {
            Count = 1;
            BookTitle = book.Title;
            Author = book.Author.Fio;
            ImagePath = book.Image.Path ?? "";
            Price = book.Price;
            BookId = book.Id;
        }

        public BasketItem()
        {

        }
        public int Count { get; set; }

        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
    }
}
