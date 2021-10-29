using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Entidades
{
    public class Agenda 
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

        public DateTime DataFim { get; set; }

        public DateTime DataInicio { get; set; }

        public string Titulo { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
