using Microsoft.EntityFrameworkCore;
using SMSAPI.Tree.Entities;

namespace SMSAPI.Tree.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<SMSs> SMSs { get; set; }
    }
}
