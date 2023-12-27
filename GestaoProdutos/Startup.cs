using GestaoProdutos.Application.Services;
using GestaoProdutos.Domain.Interfaces.Services;
using GestaoProdutos.Domain.Interfaces;
using GestaoProdutos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using GestaoProdutos.Infrastructure;

namespace GestaoProdutos.API
{
    public static class Startup
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //database//
            services.ConfigureDbContext(configuration);

            //interfaces/services//
            services.AddScoped<IAddProdutoService, AddProdutoService>();
            services.AddScoped<IGetProdutoService, GetProdutoService>();
            services.AddScoped<IUpdateProdutoService, UpdateProdutoService>();

            //repositories//
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
           
        }

    }
}
