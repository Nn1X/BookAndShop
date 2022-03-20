using System;
using System.Collections.Generic;

namespace BookAndShop.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Fio { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Address { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; } = null!;
    }
}
