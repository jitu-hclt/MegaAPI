using System;
using Microsoft.Extensions.Configuration;
using DALayer;
using DALayer.RepositoryUOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

namespace BLLayer
{
	public static class Configure
	{
		public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();

            //var keyVaultEndPoint = new Uri(configuration["VaultKey"]);
            //var secretClient = new SecretClient(keyVaultEndPoint, new DefaultAzureCredential());
            //KeyVaultSecret kvs = secretClient.GetSecret("megaltkey1");
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(kvs.Value);
            //});


            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });
        }
	}
}

