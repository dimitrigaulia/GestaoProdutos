using GestaoProdutos.Domain.Interfaces.Services;
using GestaoProdutos.Domain.Interfaces;
using GestaoProdutos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutos.Application.Services
{
    public class AddProdutoService : IAddProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public AddProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
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
    }
}
