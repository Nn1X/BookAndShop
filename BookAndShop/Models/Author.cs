using System;
using System.Collections.Generic;

namespace BookAndShop.Models
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Fio { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
