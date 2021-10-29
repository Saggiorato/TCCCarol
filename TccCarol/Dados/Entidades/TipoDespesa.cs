using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Entidades
{
    public class TipoDespesa
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorFixo { get; set; }
        public string Observacao { get; set; }
    }
}
