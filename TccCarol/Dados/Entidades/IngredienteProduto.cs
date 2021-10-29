using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TccCarol.Dados.Enum;

namespace TccCarol.Dados.Entidades
{
    public class IngredienteProduto
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid IngredienteId { get; set; }
        public decimal Quantidade { get; set; }
        public TipoMedidaEnum TipoMedida { get; set; }
    }
}
