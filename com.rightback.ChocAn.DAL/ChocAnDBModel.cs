namespace com.rightback.ChocAn.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChocAnDBModel : DbContext
    {
        public ChocAnDBModel()
            : base("name=ChocAnDBModel")
        {
        }

        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Claim> Providers { get; set; }
        public virtual DbSet<Member> Providers { get; set; }
        public virtual DbSet<Service> Providers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
