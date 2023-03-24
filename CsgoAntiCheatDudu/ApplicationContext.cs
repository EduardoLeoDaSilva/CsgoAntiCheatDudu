using Common;
using Microsoft.EntityFrameworkCore;

namespace CsgoAntiCheatDudu
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<ServerStatus> ServerStatus { get; set; }
        public DbSet<TokenDropbox> TokenDropboxes { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(x =>
            {
                x.ToTable("players");
                x.HasKey(m => m.SteamId);
                x.Property(m => m.Name).IsRequired(true).HasMaxLength(100);
                x.Property(m => m.Expiration);
                x.Property(m => m.Map);
                x.Property(m => m.IsConnected);
                x.Property(m => m.IsAntiCheatOpen);
            });

            modelBuilder.Entity<ServerStatus>(x =>
            {
                x.ToTable("ServerStatus");
                x.HasKey(m => m.Id);
                x.Property(m => m.Status);
            });


            modelBuilder.Entity<TokenDropbox>(x =>
            {
                x.ToTable("DropboxTokens");
                x.HasKey(m => m.Id);
                x.Property(m => m.Token);
                x.Property(m => m.Expiration);

            });
        }
    }
}
