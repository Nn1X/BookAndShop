using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookAndShop.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название обязательно!")]
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        [Required(ErrorMessage = "Дата обязательна!")]
        public DateTime? Date { get; set; }
        [Required(ErrorMessage = "Цена обязательна!")]
        public decimal Price { get; set; }
        
        public int IdImage { get; set; }
        public int IdAuthor { get; set; }

        [Required(ErrorMessage = "Автор обязателен!")]
        public virtual Author Author { get; set; } = null!;
        [Required(ErrorMessage = "Картинка обязательна!")]
        public virtual Image Image { get; set; } = null!;
    }
}
