using Microsoft.EntityFrameworkCore;

namespace PartyInvites.Models
{
    public class ResponseContext : DbContext
    {
        public ResponseContext(DbContextOptions<ResponseContext> options) : base(options) {}

        public DbSet<GuestResponse> Responses { get; set; }
    }
}
