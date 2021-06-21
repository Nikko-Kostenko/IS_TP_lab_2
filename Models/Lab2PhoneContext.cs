using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IS_TP_lab2.Models
{
    public class Lab2PhoneContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }
        public virtual DbSet<PhoneShop> PhoneShops { get; set; }
        public virtual DbSet<PhoneWishlist> PhoneWishlists { get; set; }
        public virtual DbSet<PhoneFunction> PhoneFunctions { get; set; }

        public Lab2PhoneContext(DbContextOptions<Lab2PhoneContext> options) :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
        