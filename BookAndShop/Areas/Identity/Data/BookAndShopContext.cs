using BookAndShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookAndShop.Data;

public class BookAndShopContext : IdentityDbContext<User>
{
    public BookAndShopContext(DbContextOptions<BookAndShopContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>();
    }
}
