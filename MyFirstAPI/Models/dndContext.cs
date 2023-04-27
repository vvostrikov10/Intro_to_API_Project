using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using MyFirstAPI.Models;

namespace MyFirstAPI.Models
{
    public class dndContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public dndContext(DbContextOptions<dndContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("dndcharacterservice");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<CharacterClass> CharacterClasses { get; set; } = null!;
        public DbSet<CharacterSubClass> CharacterSubClasses { get; set; } = null!;
    }
}
