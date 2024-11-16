using Microsoft.EntityFrameworkCore;
using SearchifyAPI.Models;

namespace SearchifyAPI.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (!context.SearchResults.Any())
            {
                context.SearchResults.AddRange(
                    new SearchResult
                    {
                        Title = "Eat. Stay. Love.",
                        Description = "An all in one 6 experience at Fratelli Vinyards awaits When you book a flight to Pune.",
                        SearchKeys = "Travel, Food, Nature",
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTlyKOEdl3qcAIeDL3u68WhrywdjqliOzeOItiXDjVgdqdZQKnm0Vnuq8ANxQR47TpR_F4&usqp=CAU"
                    },
                    new SearchResult
                    {
                        Title = "Sun Set Savour",
                        Description = "Enjoy an exclusive 6 Experience at Sula Vineyards When you book a flight to Nashik.",
                        SearchKeys = "Travel, Food, Nature",
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRXntsO_PTE6NFNDsNg8_3OmZAHR9x2wYN84A&s"
                    },
                    new SearchResult
                    {
                        Title = "Festivals From India",
                        Description = "Explore arts and culutre festivals across India.",
                        SearchKeys = "Travel, Art Forms",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Kathakali_BNC.jpg/220px-Kathakali_BNC.jpg"
                    },
                    new SearchResult
                    {
                        Title = "Travel wanderlust",
                        Description = "Travel to your next destination based on how you feel and what you like.",
                        SearchKeys = " Art Forms",
                        ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSNmlZE0vj-6GjR7mHiXfr5G8l4MI-chktdRA&s"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
