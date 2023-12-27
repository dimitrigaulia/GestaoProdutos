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
    public class UpdateProdutoService : IUpdateProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public UpdateProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task UpdateProdutoAsync(int id, Produto produto)
        {

            if (produto != null)
            {
                // Verifica se a data de fabricação é anterior à data de validade
                if (produto.DataFabricacao >= produto.DataValidade)
                {
                    throw new ArgumentException("A data de fabricação deve ser anterior à data de validade.");
                }

                // Chama o método de atualização do repositório
                await _produtoRepository.UpdateProdutoAsync(id, produto);
            }
            else
            {
                throw new ArgumentException("Produto não encontrado");
            }
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
