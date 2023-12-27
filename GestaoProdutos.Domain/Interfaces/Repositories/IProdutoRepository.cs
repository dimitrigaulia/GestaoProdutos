using GestaoProdutos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetProdutoByCodProdutoAsync(int id);
        Task<IEnumerable<Produto>> GetProdutosAsync(string descricaoProduto = null, SituacaoProduto? situacao = null, int pagina = 1, int itensPorPagina = 10);
        Task<Produto> AddProdutoAsync(Produto produto);
        Task UpdateProdutoAsync(int id, Produto produto);
        Task DeleteProdutoAsync(Produto produto);
    }

}
