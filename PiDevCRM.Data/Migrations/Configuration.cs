namespace PiDevCRM.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PiDevCRM.Data.PiDevCRMContexte>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PiDevCRM.Data.PiDevCRMContexte";
        }

        protected override void Seed(PiDevCRM.Data.PiDevCRMContexte context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
