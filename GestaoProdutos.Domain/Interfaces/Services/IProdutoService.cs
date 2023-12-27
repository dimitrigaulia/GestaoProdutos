using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProdutos.Domain.Models;

public interface IProdutoService
{
    Task<Produto> GetProdutoByCodProdutoAsync(int id);
    Task<IEnumerable<Produto>> GetProdutosAsync();
    Task<Produto> AddProdutoAsync(Produto produto);
    Task UpdateProdutoAsync(int id, Produto produto);
    Task DeleteProdutoAsync(int id);
}
