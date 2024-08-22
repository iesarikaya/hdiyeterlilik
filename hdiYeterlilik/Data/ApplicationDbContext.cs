using Microsoft.EntityFrameworkCore;
using hdiYeterlilik.Models;

namespace hdiYeterlilik.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Agreement> Agreements { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<BusinessTopic> BusinessTopics { get; set; }
        public DbSet<RiskAnalysis> RiskAnalyses { get; set; }
        public DbSet<FinancialReport> FinancialReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RiskAmount özelliği için hassasiyet ve ölçek tanımlaması
            modelBuilder.Entity<RiskAnalysis>()
                .Property(r => r.RiskAmount)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
