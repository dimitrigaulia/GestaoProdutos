using System.ComponentModel.DataAnnotations;

namespace GestaoProdutos.Domain.Models
{
    public class Produto
    {
        [Key]
        public int CodProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public SituacaoProduto Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int CodFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }

    }
    public enum SituacaoProduto
    {
        Inativo = 0,
        Ativo = 1
    }
}
