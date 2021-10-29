using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Entidades
{
    public class ClienteFornecedor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Fornecedor { get; set; }
        public string Numero { get; set; }
    }
}
