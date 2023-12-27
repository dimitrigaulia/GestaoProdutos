using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoProdutos.Domain.Interfaces.Services;
using GestaoProdutos.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IAddProdutoService _addProdutoService;
        private readonly IGetProdutoService _getProdutoService;
        private readonly IUpdateProdutoService _updateProdutoService;

        public ProdutoController(IAddProdutoService addProdutoService, IGetProdutoService getProdutoService, IUpdateProdutoService updateProdutoService)
        {
            _addProdutoService = addProdutoService ?? throw new ArgumentNullException(nameof(addProdutoService));
            _getProdutoService = getProdutoService ?? throw new ArgumentNullException(nameof(getProdutoService));
            _updateProdutoService = updateProdutoService ?? throw new ArgumentNullException(nameof(updateProdutoService));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _getProdutoService.GetProdutoByCodProdutoAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos(string? descricaoProduto = null, SituacaoProduto? situacao = null, int pagina = 1, int itensPorPagina = 10)
        {
            var produtos = await _getProdutoService.GetProdutosAsync(descricaoProduto, situacao, pagina, itensPorPagina);

            return Ok(produtos);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            if (produto.DescricaoProduto == "")
            {
                return BadRequest("Campo descricao nulo");
            }

            var novoProduto = await _addProdutoService.AddProdutoAsync(produto);

            return CreatedAtAction(nameof(GetProduto), new { id = novoProduto.CodProduto }, novoProduto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _updateProdutoService.UpdateProdutoAsync(id, produto);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _getProdutoService.GetProdutoByCodProdutoAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _updateProdutoService.DeleteProdutoAsync(id);

            return NoContent();
        }
    }
}
