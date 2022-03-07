using Microsoft.EntityFrameworkCore;

namespace profdeneme_mustafaDev_migrationsCrud.Models
{
    public class mydbcontext : DbContext
    {

        string dbconnection = "Server=.;Database=TestMustafa4;User Id=sa;Password=psw;MultipleActiveResultSets=true";

        public mydbcontext() { }

        public mydbcontext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbconnection);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<kitap>? kitap { get; set; }
        public DbSet<yazar>? yazar { get; set; }
        public DbSet<kitaptoyazar>? kitaptoyazar { get; set; }
    }
}
