using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BookAndShop.Models
{
    public partial class User: IdentityUser
    {
        public string? Fio { get; set; }
        public string? Address { get; set; }
    }
}
