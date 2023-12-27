using GestaoProdutos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace GestaoProdutos.Infrastructure
{
        public static class DatabaseExtensions
        {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];

            services.AddDbContext<MySqlContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), sqloptions =>
                {
                    sqloptions.EnableStringComparisonTranslations();
                });
            });
        }

    }
}
