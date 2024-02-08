using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RbPharma.Domain.Entities.V1;
using RbPharma.Infrastructure.Users.V1.Mappers;
using System.Configuration;

namespace RbPharma.Infrastructure.Contexts.V1
{
    public class ContextSql : DbContext
    {
        private readonly IConfiguration _configuration;

        public ContextSql(DbContextOptions<ContextSql> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public ContextSql()
        {
            
        }

        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionSql = "Server=.;Database=RbPharma;Trusted_Connection=True;TrustServerCertificate=True";

            if (_configuration !=null)
                connectionSql = _configuration.GetSection("ConnectionStrings:ConnectionSql").Value;

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connectionSql);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapping());
        }

    }
}
