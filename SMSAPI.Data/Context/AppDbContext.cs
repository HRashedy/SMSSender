using Microsoft.EntityFrameworkCore;
using SMSAPI.Data.Entities;

namespace SMSAPI.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<SMSs> SMSs { get; set; }
    }
}
