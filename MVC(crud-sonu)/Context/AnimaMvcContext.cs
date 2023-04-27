using Microsoft.EntityFrameworkCore;
using MVC_crud_sonu_.Models;

namespace MVC_crud_sonu_.Context
{
    public class AnimaMvcContext  : DbContext
    {
        public AnimaMvcContext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Zookeeper> Zookeeper { get; set; }
        public DbSet<GuestServiceAgent> GuestServiceAgent { get; set; }
        public DbSet<Users> UsersAuth { get; set; }

    }
}
