using System;
using System.Collections.Generic;

namespace BookAndShop.Models
{
    public partial class Image
    {
        public Image()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string? Path { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
