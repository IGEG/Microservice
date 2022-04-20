using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt ) : base(opt)
        {
            
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Message>()
                .HasMany(p => p.Commands)
                .WithOne(p=> p.Platform)
                .HasForeignKey(p => p.PlatformId);

            modelBuilder
                .Entity<Command>()
                .HasOne(p => p.Message)
                .WithMany(p => p.Commands)
                .HasForeignKey(p =>p.MessageId);
        }
    }
}