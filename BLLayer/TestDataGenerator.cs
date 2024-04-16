using System;
using DALayer;
using Microsoft.Extensions.DependencyInjection;

namespace BLLayer
{
	public static class TestDataGenerator
	{
		public static void Generate(IServiceProvider serviceProvider)
		{
            //Creating test data
            var context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            DALayer.SeedDatabase.Seed(context);
        }

    }
}

