using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Configuracao
{
    public class Produto : Entidades.Produto
    {
        public virtual ClienteFornecedor Fornecedor { get; set; }
        public virtual List<IngredienteProduto> Ingredientes { get; set; }
        public virtual List<IngredienteProduto> Produtos { get; set; }
        public virtual List<HistoricoCompraVenda> HistoricosCompraVenda { get; set; }
        
        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Produto>().ToTable("Produtos");
            builder.Entity<Produto>().HasKey(x => x.Id);
            builder.Entity<Produto>().HasIndex(x => x.Id);
            builder.Entity<Produto>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<Produto>()
                .HasOne(x => x.Fornecedor)
                .WithMany(x => x.Produtos)
                .IsRequired(false)
                .HasForeignKey(x => x.FornecedorId);
        }
    }
}
