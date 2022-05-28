
using Microsoft.EntityFrameworkCore;

    public class Context : DbContext
    {
        public DbSet<TblAdmin> tblAdmins  { get; set; }
        public DbSet<TblProduct> tblProducts { get; set; }
        public DbSet<TblUser> tblUsers { get; set; }
              public DbSet<Tbl_Factor> tbl_Factors { get; set; }
        
                 protected override void OnConfiguring(DbContextOptionsBuilder db)
        {
            db.UseSqlServer("Data source =. ; initial Catalog = FruitShop6; integrated Security = true ;");
        }
    }