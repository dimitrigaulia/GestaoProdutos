using GestaoProdutos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Domain.Interfaces.Services
{
    public interface IUpdateProdutoService
    {
        Task UpdateProdutoAsync(int id, Produto produto);
        //Task DeleteProdutoAsync(int id);
    }
}
