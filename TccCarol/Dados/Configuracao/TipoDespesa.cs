using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Configuracao
{
    public class TipoDespesa : Entidades.TipoDespesa
    {
        public virtual List<HistoricoDespesa> HistoricosDespesa { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<TipoDespesa>().ToTable("TiposDespesas");
            builder.Entity<TipoDespesa>().HasKey(x => x.Id);
            builder.Entity<TipoDespesa>().HasIndex(x => x.Id);
            builder.Entity<TipoDespesa>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
