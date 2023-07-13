using PlatformService.Models;

namespace PlatformServices.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using( var serviseScope  = app.ApplicationServices.CreateScope())
            {
                SeedData(serviseScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Sending data");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free"},
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We alrady have data");
            }
        }
    }
}