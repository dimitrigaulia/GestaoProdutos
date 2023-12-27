using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProdutos.Domain.Interfaces;
using GestaoProdutos.Domain.Interfaces.Services;
using GestaoProdutos.Domain.Models;

namespace GestaoProdutos.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<Produto> GetProdutoByCodProdutoAsync(int id)
        {
            return await _produtoRepository.GetProdutoByCodProdutoAsync(id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            return await _produtoRepository.GetProdutosAsync();
        }

        public async Task<Produto> AddProdutoAsync(Produto produto)
        {
            // Valida se a data de fabricação é menor que a data de validade //
            if (produto.DataFabricacao >= produto.DataValidade)
            {
                throw new ArgumentException("A data de fabricação deve ser anterior à data de validade.");
            }

            return await _produtoRepository.AddProdutoAsync(produto);
        }

        public async Task UpdateProdutoAsync(int id, Produto produto)
        {
            // Verifica se a data de fabricação é menor que a data de validade //
            if (produto.DataFabricacao >= produto.DataValidade)
            {
                throw new ArgumentException("A data de fabricação deve ser anterior à data de validade.");
            }

            await _produtoRepository.UpdateProdutoAsync(id, produto);
        }

        public async Task DeleteProdutoAsync(int id)
        {
            var produto = await _produtoRepository.GetProdutoByCodProdutoAsync(id);

            if (produto != null)
            {
                produto.Situacao = 0;

                await _produtoRepository.DeleteProdutoAsync(produto);
            }
            else
            {
                throw new ArgumentException("Produto não encontrado");
            }
        }
    }
}
