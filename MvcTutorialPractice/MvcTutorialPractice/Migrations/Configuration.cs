namespace MvcTutorialPractice.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcTutorialPractice.Models.DbContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }


        //Este metodo se ejecuta cada vez que invocamos update-database
        protected override void Seed(MvcTutorialPractice.Models.DbContexto context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
