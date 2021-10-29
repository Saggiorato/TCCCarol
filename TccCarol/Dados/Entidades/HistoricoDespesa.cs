﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Entidades
{
    public class HistoricoDespesa
    {
        public Guid Id { get; set; }
        public Guid TipoDespesaId { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public bool Porcentagem { get; set; }
    }
}
