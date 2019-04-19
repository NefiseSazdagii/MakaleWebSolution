namespace MakaleWebDataAccesLayer
{
    using MakaleWeb.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DatabaseContext : DbContext
    {
        //databasim oluþsun diye database context oluþturduk 

        public virtual DbSet<Makaleler> Makaleler { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Yorumlar> Yorumlar { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Begeniler> Begeniler { get; set; }

        public DatabaseContext() : base("name=DatabaseContext")
        {
            Database.SetInitializer(new OrnekData()); //create olurken bunu çalýþtýrsýn..

        }
    }
}