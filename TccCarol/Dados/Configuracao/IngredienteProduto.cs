using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TccCarol.Dados.Configuracao
{
    public class IngredienteProduto : Entidades.IngredienteProduto
    {
        public virtual Produto Produto { get; set; } //produto que esse ingrediente gera
        public virtual Produto Ingrediente { get; set; } //ingrediente em si

        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<IngredienteProduto>().ToTable("IngredienteProduto");
            builder.Entity<IngredienteProduto>().HasKey(x => x.Id);
            builder.Entity<IngredienteProduto>().HasIndex(x => x.Id);
            builder.Entity<IngredienteProduto>().Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Entity<IngredienteProduto>()
                .HasOne(x => x.Produto)
                .WithMany(x => x.Ingredientes)
                .IsRequired(true)
                .HasForeignKey(x => x.ProdutoId);

            builder.Entity<IngredienteProduto>()
                .HasOne(x => x.Ingrediente)
                .WithMany(x => x.Produtos)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.IngredienteId);
        }
    }
}
