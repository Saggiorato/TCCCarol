using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Entidades
{
    public class HistoricoCompraVenda
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public Guid? ClienteFornecedorId { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public bool Venda { get; set; }
    }
}
