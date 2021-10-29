using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Configuracao
{
    public class HistoricoCompraVenda : Entidades.HistoricoCompraVenda
    {
        public virtual Produto Produto { get; set; }
        public virtual ClienteFornecedor ClienteFornecedor { get; set; }

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<HistoricoCompraVenda>().ToTable("HistoricosCompraVenda");
            builder.Entity<HistoricoCompraVenda>().HasKey(x => x.Id);
            builder.Entity<HistoricoCompraVenda>().HasIndex(x => x.Id);
            builder.Entity<HistoricoCompraVenda>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<HistoricoCompraVenda>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.HistoricosCompraVenda)
                .IsRequired(true)
                .HasForeignKey(x => x.ProdutoId);

            builder.Entity<HistoricoCompraVenda>()
                .HasOne(x => x.ClienteFornecedor)
                .WithMany(x => x.HistoricosCompraVenda)
                .IsRequired(false)
                .HasForeignKey(x => x.ClienteFornecedorId);
        }
    }
}
