using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkerAntixiter
{
    public class ApplicationContext :DbContext
    {
        public DbSet<Player> Players { get; set; }

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
        }
    }
}
