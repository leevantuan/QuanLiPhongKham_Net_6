using Microsoft.EntityFrameworkCore;

namespace QuanLiPhongKham.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
            
        }
        //Dbset start
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<BHYT> Bhyts { get; set; }

        public DbSet<ProvideNumber> ProvideNumbers { get; set; }

        //Dbset end
    }
}
