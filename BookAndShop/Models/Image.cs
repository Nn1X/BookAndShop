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
        public long? Size { get; set; }
        public byte[] Data { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
