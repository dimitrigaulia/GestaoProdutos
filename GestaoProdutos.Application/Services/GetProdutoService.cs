using GestaoProdutos.Domain.Interfaces;
using GestaoProdutos.Domain.Interfaces.Services;
using GestaoProdutos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Application.Services
{
    public class GetProdutoService : IGetProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public GetProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public Task<Produto> GetProdutoByCodProdutoAsync(int id)
        {
            return _produtoRepository.GetProdutoByCodProdutoAsync(id);
        }

        public Task<IEnumerable<Produto>> GetProdutosAsync(string descricaoProduto = null, SituacaoProduto? situacao = null, int pagina = 1, int itensPorPagina = 10)
        {
            return _produtoRepository.GetProdutosAsync(descricaoProduto, situacao, pagina, itensPorPagina);
        }
    }
}
