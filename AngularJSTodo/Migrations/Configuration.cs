namespace AngularJSTodo.Migrations
{
    using AngularJSTodo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularJSTodo.Models.TodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngularJSTodo.Models.TodoContext context)
        {
            var random = new Random();

            var items = Enumerable
                        .Range(1,50)
                        .Select(o =>
                                new Todo{
                                    DueDate = new DateTime(2013, random.Next(1,12), random.Next(1,28)),
                                    Priority = (byte)random.Next(10),
                                    Text =string.Format("Todo nr. {0}",  o.ToString())
                        }).ToArray();

            context.Todoes.AddOrUpdate(item => new { item.Text},items);

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
        }
    }
}
