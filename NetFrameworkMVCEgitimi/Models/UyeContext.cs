using System.Data.Entity;

namespace NetFrameworkMVCEgitimi.Models
{
    public class UyeContext : DbContext
    {
        public DbSet<Uye> Uyeler { get; set; }
    }
}