using GestaoProdutos.Domain.Interfaces;
using GestaoProdutos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MySqlContext _context;

        public ProdutoRepository(MySqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Produto> GetProdutoByCodProdutoAsync(int id)
        {
            return await _context.Produto.FirstOrDefaultAsync(p => p.CodProduto == id);
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync(string descricaoProduto = null, SituacaoProduto? situacao = null, int pagina = 1, int itensPorPagina = 10)
        {
            var query = _context.Produto.AsQueryable();

            // Filtros
            if (!string.IsNullOrEmpty(descricaoProduto))
            {
                query = query.Where(p => p.DescricaoProduto.Contains(descricaoProduto));
            }

            if (situacao.HasValue)
            {
                query = query.Where(p => p.Situacao == situacao.Value);
            }


            // Paginação
            var totalItens = await query.CountAsync();
            var produtosPaginados = await query
                .Skip((pagina - 1) * itensPorPagina)
                .Take(itensPorPagina)
                .ToListAsync();

            return produtosPaginados;
        }

        public async Task<Produto> AddProdutoAsync(Produto produto)
        {
            _context.Produto.Add(produto);

            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task UpdateProdutoAsync(int id, Produto produto)
        {
            var existeProduto = await _context.Produto.FirstOrDefaultAsync(p => p.CodProduto == id);

            if (existeProduto != null)
            {
                existeProduto.DescricaoProduto = produto.DescricaoProduto;
                existeProduto.Situacao = produto.Situacao;
                existeProduto.DataFabricacao = produto.DataFabricacao;
                existeProduto.DataValidade = produto.DataValidade;
                existeProduto.CodFornecedor = produto.CodFornecedor;
                existeProduto.DescricaoFornecedor = produto.DescricaoFornecedor;

                _context.Update(existeProduto);

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Produto não encontrado");
            }
        }

        public async Task DeleteProdutoAsync(Produto produto)
        {
            await _context.SaveChangesAsync();
        }
    }
}
