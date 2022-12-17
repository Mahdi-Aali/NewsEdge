using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsEdge.DataAccess.Models.PrimaryModels;

namespace NewsEdge.DataAccess.Models.Context;

public class NewsEdgeSeedData
{
    private static NewsEdgeUser user = new NewsEdgeUser()
    {
        UserName = "Admin",
        Email = "mahdi1383harold@outlook.com",
        Bio = "Admin Account",
        PhoneNumber = "09052730661",
        EmailConfirmed = true,
        PhoneNumberConfirmed = true,
        RealName = "مدیر سایت"
    };


    public static void SeedData(IServiceProvider serviceProvider)
    {
        SeedDataAsync(serviceProvider).Wait();
    }

    private static async Task SeedDataAsync(IServiceProvider serviceProvider)
    {
        var service = await Task.FromResult(serviceProvider.CreateAsyncScope().ServiceProvider);

        NewsEdgeContext context = service.GetRequiredService<NewsEdgeContext>();
        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            await context.Database.MigrateAsync();
        }

        UserManager<NewsEdgeUser> userManager = service.GetRequiredService<UserManager<NewsEdgeUser>>();
        RoleManager<IdentityRole<long>> roleManager = service.GetRequiredService<RoleManager<IdentityRole<long>>>();

        if (await userManager.FindByNameAsync("Admin") is null)
        {
            var result = await userManager.CreateAsync(user, "M4#d1@4l1$Ma7415369");

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new()
                {
                    Name = "Admin"
                });
                await roleManager.CreateAsync(new()
                {
                    Name = "User"
                });
            }

            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
        if (!await context.NewsSections.AnyAsync())
        {
            await context.NewsSections.AddRangeAsync(
                new() { SectionName = "بالاترین اخبار" },
                new() { SectionName = "اخبار پیشنهادی"},
                new() { SectionName = "اخبار یوتیوب"},
                new() { SectionName = "اخبار میانی اول" },
                new() { SectionName = "اخبار میانی دوم" },
                new() { SectionName = "اخبار میانی سوم" },
                new() { SectionName = "اخبار نهایی"}
                );
            await context.SaveChangesAsync();
        }
    }
}
