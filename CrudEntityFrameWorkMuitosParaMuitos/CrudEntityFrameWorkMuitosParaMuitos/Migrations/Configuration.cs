namespace CrudEntityFrameWorkMuitosParaMuitos.Migrations
{
    using CrudEntityFrameWorkMuitosParaMuitos.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CrudEntityFrameWorkMuitosParaMuitos.Context.LivrariaContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LivrariaContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
