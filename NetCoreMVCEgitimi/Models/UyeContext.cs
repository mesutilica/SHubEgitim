using Microsoft.EntityFrameworkCore;

namespace NetCoreMVCEgitimi.Models
{
    public class UyeContext : DbContext
    {
        public DbSet<Uye> Uyeler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=UyeDb; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
