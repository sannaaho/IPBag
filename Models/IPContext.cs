using Microsoft.EntityFrameworkCore;

namespace IPBag.Models
{
    public class IPContext : DbContext
    {
        public IPContext(DbContextOptions<IPContext> options) : base(options)
        {
        }

        public DbSet<IPv4Addresses> IpAddresses { get; set; }
        public DbSet<EventsModel> Eventlog { get; set; }
    }
}
