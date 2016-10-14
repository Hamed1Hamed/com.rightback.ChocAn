namespace com.rightback.ChocAn.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<com.rightback.ChocAn.DAL.ChocAnDBModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(com.rightback.ChocAn.DAL.ChocAnDBModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Providers.AddOrUpdate(p=> p.Email,
                new Provider { City = "Istanbul" , Code = "123456789" , Email="beribener@hotmail.com", Name="Beri Bener",StreetAddres="Demet Sok.",Zip="34370" },
                new Provider { City = "Milwaukee", Code = "223456789", Email = "osmik@darci.com", Name = "Osman Darcan", StreetAddres = "Abc Apt. 1245", Zip = "54370" },
                new Provider { City = "Franklin", Code = "323456789", Email = "beribener@hotmail.com", Name = "Beri Bener", StreetAddres = "Demet Sok.", Zip = "64370" }
                );
        }
    }
}
