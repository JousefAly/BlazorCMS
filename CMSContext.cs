using AuctionTypesCMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionTypesCMS
{
    public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options): base(options)
        {
        }
        public virtual DbSet<AuctionType> AuctionTypes { get; set; }

    }
}
