using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Configuracao
{
    public class HistoricoDespesa : Entidades.HistoricoDespesa
    {
        public virtual TipoDespesa TipoDespesa { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<HistoricoDespesa>().ToTable("HistoricosDespesa");
            builder.Entity<HistoricoDespesa>().HasKey(x => x.Id);
            builder.Entity<HistoricoDespesa>().HasIndex(x => x.Id);
            builder.Entity<HistoricoDespesa>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<HistoricoDespesa>()
                .HasOne(x => x.TipoDespesa)
                .WithMany(x => x.HistoricosDespesa)
                .IsRequired(true)
                .HasForeignKey(x => x.TipoDespesaId);
        }
    }
}
