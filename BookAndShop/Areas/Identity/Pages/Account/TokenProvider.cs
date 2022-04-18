using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndShop.Areas.Identity
{
    public class TokenProvider
    {
        public string XsrfToken { get; set; }
        public string RefreshToken { get; set; } 
    }
}
