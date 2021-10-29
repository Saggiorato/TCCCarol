using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccCarol.Dados.Enum;

namespace TccCarol.Dados.Entidades
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoAtual { get; set; }
        public TipoMedidaEnum TipoMedidaPreco { get; set; }
        public int Estoque { get; set; }
        public Guid? FornecedorId { get; set; }
        public decimal OutrasDespesas { get; set; }
        public TipoMedidaEnum TipoMedida { get; set; } //acho que tem que retirar
        public int QuantidadeFabrica { get; set; }
        public bool Ingrediente { get; set; } // se eh ingrediente

    }
}
