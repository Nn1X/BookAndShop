using System;
using System.Collections.Generic;

namespace BookAndShop.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly? Date { get; set; }
        public decimal Price { get; set; }
        public int IdImage { get; set; }
        public int IdAuthor { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Image Image { get; set; } = null!;
    }
}
