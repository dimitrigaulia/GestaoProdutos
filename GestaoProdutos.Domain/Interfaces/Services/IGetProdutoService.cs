using GestaoProdutos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Domain.Interfaces.Services
{
    public interface IGetProdutoService
    {
        Task<Produto> GetProdutoByCodProdutoAsync(int id);
        Task<IEnumerable<Produto>> GetProdutosAsync(string descricaoProduto = null, SituacaoProduto? situacao = null, int pagina = 1, int itensPorPagina = 10);
    }
}
