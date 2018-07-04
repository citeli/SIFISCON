using System.Collections.Generic;

namespace Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Estoque { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
    }
}
